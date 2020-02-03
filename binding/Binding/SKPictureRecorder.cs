﻿using System;

namespace SkiaSharp
{
	public unsafe class SKPictureRecorder : SKObject
	{
		[Preserve]
		internal SKPictureRecorder (IntPtr handle, bool owns)
			: base (handle, owns)
		{
		}

		public SKPictureRecorder ()
			: this (SkiaApi.sk_picture_recorder_new (), true)
		{
			if (Handle == IntPtr.Zero)
				throw new InvalidOperationException ("Unable to create a new SKPictureRecorder instance.");
		}

		protected override void DisposeNative () =>
			SkiaApi.sk_picture_recorder_delete (Handle);

		// BeginRecording

		public SKCanvas BeginRecording (SKRect cullRect) =>
			GetObject<SKCanvas> (SkiaApi.sk_picture_recorder_begin_recording (Handle, &cullRect), false);

		// EndRecording

		public SKPicture EndRecording () =>
			GetObject<SKPicture> (SkiaApi.sk_picture_recorder_end_recording (Handle));

		public SKDrawable EndRecordingAsDrawable () =>
			GetObject<SKDrawable> (SkiaApi.sk_picture_recorder_end_recording_as_drawable (Handle));

		// RecordingCanvas

		public SKCanvas RecordingCanvas =>
			GetObject<SKCanvas> (SkiaApi.sk_picture_get_recording_canvas (Handle), false);
	}
}
