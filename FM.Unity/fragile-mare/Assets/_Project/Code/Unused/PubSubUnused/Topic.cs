using System;
using System.Collections.Generic;
using Debug = _Project.Code.Unused.UtilsUnused.WDebugUnused.Debug;

namespace _Project.Code.Unused.PubSubUnused
{
    /// <summary>
    /// Топик, тема (topic): объект для публикации сообщений и подписки на них.
    /// Паблишеры (publishers): те, кто публикует сообщения с помощью метода Publish.
    /// Подписчики (subscribers): те, кто обрабатывает сообщения. Подписываются с помощью метода Subscribe.
    /// Сообщения: Кастомные классы, которые передаются от паблишеров к подписчикам на обработку.
    /// !!!WARNING: Обязательно отписываться от топика с помощью класса <see cref="Subscription"/>,
    /// который выдаётся после подписки на топик.
    ///
    /// Преимущества:
    /// - отсутствие прямой связности: классам не нужно знать ничего друг о друге, нужно знать только о топике.
    /// - гибкость: паблишеров и подписчиков может быть сколько угодно и их можно легко менять. 
    /// - распределение ответственности: легко распределить функциональность по классам, можно легко определять,
    /// кто и какое сообщение будет обрабатывать.
    ///
    /// Недостатки:
    /// - трудно тестировать.
    /// - трудно охватить все кейсы использования топика и их прописать.
    ///
    /// ПРИМЕР:
    /// Например, нам нужно как-то связать перемещение в игре и ввод от игрока. При этом должна присутствовать
    /// возможность переопределить ввод (хоткеи). Для этого мы создаём три топика:
    /// player.input.actions, player.input.override, player.input.config.
    /// 
    /// В player.input.actions мы публикуем сообщения из класса, который отвечает за ввод (InputActions),
    /// а подписываемся на топик в классе, который отвечает за перемещение игрока (PlayerMovement).
    /// В сообщениях будут содержаться действия игрока (MoveForward, MoveRight и т.д.) по которым
    /// мы будем определять, что применять к персонажу игрока (переместить вперёд, вправо и т.д.).
    /// 
    /// Для переопределения ввода мы публикуем из InputActions в player.input.config наш текущий конфиг ввода.
    /// В классе для построения UI (OverrideUI) мы подписываемся на player.input.config, считываем конфиг ввода и
    /// показываем наш интерфейс, где можно нажать на нужные сочетание клавиш и переопределить их.
    /// 
    /// После того, как игрок решил, какую кнопку поменять, в player.input.override из OverrideUI мы публикуем
    /// сообщение, в котором содержится действие и новое для него сочетание клавиш. В классе InputActions
    /// мы подписываемся на player.input.override и определяем сочетание клавиш в соответствии с сообщением.
    ///
    /// Таким образом мы избегаем прямой связности и свободно можем распределить ответственность классов.
    /// </summary>
    /// <typeparam name="T">Класс сообщений. Обычно можно назвать "...Params".</typeparam>
    [Obsolete("Unused.")]
    public class Topic<T> : ITopicPublisher<T>, ITopicSubscriber<T>
    {
        public string Name;
        
        /// Подписчики на топик.
        private event Action<T> Events;

        /// Валидаторы сообщений. Если валидатор возвращает false, то сообщение пропускается
        /// подписчиком и не обрабатывается.
        private readonly List<IValidator> _validators = new();
        
        /// Сохраняем последнее опубликованное сообщение.
        /// Нужно для обработки подписчиками, которые подписались после публикации сообщения.
        /// (Это действительно закрывает много неприятных кейсов).
        /// 
        /// Например, мы опубликовали изменение игрового контекста на Inventory. После этого
        /// пришёл новый объект и подписался на топик. Если мы не дадим ему _lastPublish на
        /// обработку, то он не будет знать об актуальном игровом контексте и будет использовать
        /// стандартный (Например, Game или MainMenu).
        private T _lastPublish;

        public Topic(string name)
        {
            Name = name;
        }
    
        /// <summary>
        /// Публикуем сообщение в топик.
        /// </summary>
        /// <param name="parameters">Сообщение в топик.</param>
        public void Publish(T parameters)
        {
            if (Events == null)
            {
                Debug.LogWarning("Publish is called, but events in Topic is null");
            }
            
            Debug.Log($"Topic called publish. topic: {Name}, params: {parameters}.");
            Events?.Invoke(parameters);
            
            _lastPublish = parameters;
        }

        /// <summary>
        /// Подписываемся на сообщения из топика.
        /// </summary>
        /// <param name="func">Функция для чтения сообщений из топика.</param>
        /// <param name="subscription">
        ///     Класс для управления подпиской на топик.
        /// 
        ///     !!! WARNING: При Destroy объекта, который подписался на топик, нужно
        ///     обязательно вызывать функцию Unsubscribe в этом классе!!! Иначе бан.
        /// </param>
        public void Subscribe(Action<T> func, out Subscription subscription)
        {
            var enabled = true;
            
            Action<T> wrappedFunc = parameters =>
            {
                if(!enabled) return;

                // todo: сделать передаваемыми в функцию
                foreach (var validator in _validators)
                {
                    if (!validator.Validate()) return;
                }
                
                Debug.Log($"Topic called subscribe function. topic: {Name}, func: {func.Method.Name}.");
                func(parameters);
            };
            
            Events += wrappedFunc;
            
            if (!EqualityComparer<T>.Default.Equals(_lastPublish, default))
            {
                wrappedFunc(_lastPublish);
            }
            
            Action unsubscribe = () =>
            {
                // if topic was destroyed earlier than object subscribed
                if (Events == null)
                {
                    Debug.LogError("events is null >_<");
                    return;
                }
                    
                Events -= wrappedFunc;
            };

            Action switchState = () =>
            {
                enabled = !enabled;
            };

            Action<bool> setState = state =>
            {
                enabled = state;
            };

            subscription = new Subscription(unsubscribe, switchState, setState);
        }

        public void AddValidator(IValidator validator)
        {
            _validators.Add(validator);
        }
    }
    
    /// <summary>
    /// Класс для управления подпиской на топик.
    /// 
    /// !!! WARNING: При Destroy объекта, который подписался на топик, нужно
    /// обязательно вызывать функцию Unsubscribe в этом классе!!! Иначе бан.
    /// </summary>
    [Obsolete("Unused.")]
    public class Subscription
    {
        private readonly Action _unsubscribe;
        private readonly Action _switchState;
        private readonly Action<bool> _setState;
        //private readonly Action<T> _func;

        // todo: может есть более красивый способ определять эти функции (unsubscribe и т.д.)?
        public Subscription(Action unsubscribe, Action switchState, Action<bool> setState)//, Action<T> func)
        {
            _unsubscribe = unsubscribe;
            _switchState = switchState;
            _setState = setState;
        }

        /// !!! WARNING: При Destroy объекта, который подписался на топик, нужно
        /// обязательно вызывать эту функцию!!! Иначе бан.
        public void Unsubscribe()
        {
            if (_unsubscribe == null)
            {
                Debug.LogError("unsubscribe is null (/_＼)");
                return;
            }
            _unsubscribe();
        }

        /// Начинаем или перестаём читать сообщения топика, не отписываясь от него.
        public void SwitchState()
        {
            if (_switchState == null)
            {
                Debug.LogError("switchState is null (ノωヽ)");
                return;
            }
            _switchState();
        }

        /// Начинаем или перестаём читать сообщения топика, не отписываясь от него.
        public void SetState(bool state)
        {
            if (_setState == null)
            {
                Debug.LogError("setState is null (w-w)");
                return;
            }
            _setState(state);
        }
    }
}
