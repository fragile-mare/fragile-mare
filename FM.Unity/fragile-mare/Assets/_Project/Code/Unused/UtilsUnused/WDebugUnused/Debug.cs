using System;
using System.Diagnostics;

namespace _Project.Code.Unused.UtilsUnused.WDebugUnused
{
	[Obsolete("Unused.")]
	public static class Debug
	{
		// Для включения логирования прописать "UNITY_EDITOR", для выключения - всё что угодно.
		private const string ConditionString = "UNITY_EDITOR";
		
		[Conditional(ConditionString)]
		public static void LogInfo(string message, UnityEngine.Object context = null) {
			UnityEngine.Debug.Log(message, context);
		}

		[Conditional(ConditionString)]
		public static void Log(string message, UnityEngine.Object context = null) {
			UnityEngine.Debug.Log(message, context);
		}

		[Conditional(ConditionString)]
		public static void LogWarning(string message, UnityEngine.Object context = null) {
			UnityEngine.Debug.LogWarning(message, context);
		}

		[Conditional(ConditionString)]
		public static void LogError(string message, UnityEngine.Object context = null) {
			UnityEngine.Debug.LogError(message, context);
		}

		[Conditional(ConditionString)]
		public static void LogException(System.Exception e) {
			UnityEngine.Debug.LogError(e.Message);
		}
	}
}