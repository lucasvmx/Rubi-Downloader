using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubi_Downloader
{
	public sealed class EncodingProgress
	{
		public int Frame { get; set; }
		public double Fps { get; set; }
		public double Quality { get; set; }
		public long SizeKiB { get; set; }
		public TimeSpan Time { get; set; }
		public double BitrateKbps { get; set; }
		public double Speed { get; set; }
		public TimeSpan Elapsed { get; set; }

		public EncodingProgress(
		int frame,
		double fps,
		double quality,
		long sizeKiB,
		TimeSpan time,
		double bitrateKbps,
		double speed,
		TimeSpan elapsed)
		{
			Frame = frame;
			Fps = fps;
			Quality = quality;
			SizeKiB = sizeKiB;
			Time = time;
			BitrateKbps = bitrateKbps;
			Speed = speed;
			Elapsed = elapsed;
		}
	}

}
