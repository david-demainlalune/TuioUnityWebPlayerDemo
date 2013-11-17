using System.Collections.Generic;
using TUIOsharp;
using UnityEngine;
using LitJson;

namespace TouchScript.InputSources
{

	public class JsonMappedCursor{
		public int id;
		public double x;
		public double y;
	}

	/// <summary>
	/// Processes TUIO 1.0 input.
	/// </summary>
	[AddComponentMenu("TouchScript/Input Sources/TUIO Web socket Input")]
	public class TuioWebSocketInput : InputSourcePro
	{
		#region Unity fields

		#endregion

		#region Private variables

		// key is cursorId, value is touchScript internalId
		private Dictionary<int, int> cursorToInternalId = new Dictionary<int, int>();
		private int screenWidth;
		private int screenHeight;

		#endregion

		#region Unity

		/// <inheritdoc />
		protected override void Start()
		{
			base.Start();
			Application.ExternalCall("unityIsReady");
		}

		/// <inheritdoc />
		protected override void Update()
		{
			base.Update();
			screenWidth = Screen.width;
			screenHeight = Screen.height;
		}

		/// <inheritdoc />
		protected override void OnDestroy()
		{
			base.OnDestroy();
		}

		#endregion

		#region Event handlers

		private void OnCursorAdded(string jsonCursor)
		{
			var cursor = Deserialize(jsonCursor);

			lock (this)
			{
				var x = cursor.X*screenWidth;
				var y = (1 - cursor.Y)*screenHeight;
				int existingCursor = beginTouch(new Vector2(x, y));

				cursorToInternalId.Add(cursor.Id, existingCursor);
			}
		}

		private void OnCursorUpdated(string jsonCursor)
		{
			var cursor = Deserialize(jsonCursor);

			lock (this)
			{
				int existingCursor;

				if (!cursorToInternalId.TryGetValue(cursor.Id, out existingCursor)) return;


				var x = cursor.X*screenWidth;
				var y = (1 - cursor.Y)*screenHeight;

				moveTouch(existingCursor, new Vector2(x, y));
			}
		}

		private void OnCursorRemoved(string jsonCursor)
		{
			var cursor = Deserialize(jsonCursor);

			lock (this)
			{
				int existingCursor;

				if (!cursorToInternalId.TryGetValue(cursor.Id, out existingCursor)) return;

				cursorToInternalId.Remove(cursor.Id);
				endTouch(existingCursor);
			}
		}

		// TODO: remove intermediary step
		private TuioCursor Deserialize(string jsonString){
			JsonMappedCursor c = JsonMapper.ToObject<JsonMappedCursor>(jsonString);
			return new TuioCursor(c.id, (float) c.x, (float) c.y);
		}

		#endregion
	}
}