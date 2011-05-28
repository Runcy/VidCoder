﻿namespace HandBrake.Interop
{
	public partial class NativeConstants
	{
		public const int HB_ACODEC_MASK = 0x0000FF00;
		public const int HB_ACODEC_FAAC = 0x00000100;
		public const int HB_ACODEC_LAME = 0x00000200;
		public const int HB_ACODEC_VORBIS = 0x00000400;
		public const int HB_ACODEC_AC3 = 0x00000800;
		public const int HB_ACODEC_MPGA = 0x00001000;
		public const int HB_ACODEC_LPCM = 0x00002000;
		public const int HB_ACODEC_DCA = 0x00004000;
		public const int HB_ACODEC_FFMPEG = 0x00008000;
		public const int HB_ACODEC_CA_AAC = 0x00010000;
		public const int HB_ACODEC_PASS_FLAG = 0x40000000;
		public const int HB_ACODEC_PASS_MASK = HB_ACODEC_AC3 | HB_ACODEC_DCA;
		public const int HB_ACODEC_AC3_PASS = HB_ACODEC_AC3 | HB_ACODEC_PASS_FLAG;
		public const int HB_ACODEC_DCA_PASS = HB_ACODEC_DCA | HB_ACODEC_PASS_FLAG;
		public const int HB_ACODEC_ANY = HB_ACODEC_MASK | HB_ACODEC_PASS_FLAG;

		public const int HB_SUBSTREAM_BD_TRUEHD = 0x72;
		public const int HB_SUBSTREAM_BD_AC3 = 0x76;
		public const int HB_SUBSTREAM_BD_DTSHD = 0x72;
		public const int HB_SUBSTREAM_BD_DTS = 0x71;

		public const int HB_AMIXDOWN_DCA_FORMAT_MASK = 0x00FFF000;
		public const int HB_AMIXDOWN_A52_FORMAT_MASK = 0x00000FF0;
		public const int HB_AMIXDOWN_DISCRETE_CHANNEL_COUNT_MASK = 0x0000000F;
		public const int HB_AMIXDOWN_MONO = 0x01000001;
		public const int HB_AMIXDOWN_STEREO = 0x02002022;
		public const int HB_AMIXDOWN_DOLBY = 0x042070A2;
		public const int HB_AMIXDOWN_DOLBYPLII = 0x084094A2;
		public const int HB_AMIXDOWN_6CH = 0x10089176;

		public const int HB_INPUT_CH_LAYOUT_MONO = 0x0110010;
		public const int HB_INPUT_CH_LAYOUT_STEREO = 0x0220020;
		public const int HB_INPUT_CH_LAYOUT_DOLBY = 0x0320031;
		public const int HB_INPUT_CH_LAYOUT_3F = 0x0430030;
		public const int HB_INPUT_CH_LAYOUT_2F1R = 0x0521021;
		public const int HB_INPUT_CH_LAYOUT_3F1R = 0x0631031;
		public const int HB_INPUT_CH_LAYOUT_2F2R = 0x0722022;
		public const int HB_INPUT_CH_LAYOUT_3F2R = 0x0832032;
		public const int HB_INPUT_CH_LAYOUT_4F2R = 0x0942042;
		public const int HB_INPUT_CH_LAYOUT_3F4R = 0x0a34034;
		public const int HB_INPUT_CH_LAYOUT_HAS_LFE = 0x0000100;
		public const int HB_INPUT_CH_LAYOUT_DISCRETE_FRONT_MASK = 0x00F0000;
		public const int HB_INPUT_CH_LAYOUT_DISCRETE_REAR_MASK = 0x000F000;
		public const int HB_INPUT_CH_LAYOUT_DISCRETE_LFE_MASK = 0x0000F00;
		public const int HB_INPUT_CH_LAYOUT_DISCRETE_NO_LFE_MASK = 0xFFFF0FF;
		public const int HB_INPUT_CH_LAYOUT_ENCODED_FRONT_MASK = 0x00000F0;
		public const int HB_INPUT_CH_LAYOUT_ENCODED_REAR_MASK = 0x000000F;

		public const int HB_VCODEC_MASK = 0x0000FF;
		public const int HB_VCODEC_X264 = 0x000001;
		public const int HB_VCODEC_THEORA = 0x000002;
		public const int HB_VCODEC_FFMPEG_MPEG4 = 0x000010;
		public const int HB_VCODEC_FFMPEG = HB_VCODEC_FFMPEG_MPEG4;
		public const int HB_VCODEC_FFMPEG_MPEG2 = 0x000020;
		public const int HB_VCODEC_FFMPEG_MASK = 0x0000F0;

		public const int HB_MUX_MASK = 0xFF0000;
		public const int HB_MUX_MP4 = 0x010000;
		public const int HB_MUX_MKV = 0x200000;

		public const int HBTF_NO_IDR = 1 << 0;

		public const int HB_STATE_IDLE = 1;
		public const int HB_STATE_SCANNING = 2;
		public const int HB_STATE_SCANDONE = 4;
		public const int HB_STATE_WORKING = 8;
		public const int HB_STATE_PAUSED = 16;
		public const int HB_STATE_WORKDONE = 32;
		public const int HB_STATE_MUXING = 64;

		public const int HB_ERROR_NONE = 0;
		public const int HB_ERROR_CANCELED = 1;
		public const int HB_ERROR_UNKNOWN = 2;

		public const int AUDIO_F_DOLBY = 1 << 31;

		public const int HB_FRAME_IDR = 0x01;
		public const int HB_FRAME_I = 0x02;
		public const int HB_FRAME_AUDIO = 0x04;
		public const int HB_FRAME_P = 0x10;
		public const int HB_FRAME_B = 0x20;
		public const int HB_FRAME_BREF = 0x40;
		public const int HB_FRAME_KEY = 0x0F;
		public const int HB_FRAME_REF = 0xF0;

		public const int HB_CONFIG_MAX_SIZE = 8192;

		public const int HB_FILTER_DETELECINE = 1;
		public const int HB_FILTER_DEINTERLACE = 2;
		public const int HB_FILTER_DEBLOCK = 3;
		public const int HB_FILTER_DENOISE = 4;
		public const int HB_FILTER_DECOMB = 5;
		public const int HB_FILTER_ROTATE = 6;
	}
}
