using Rubi_Downloader;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public static class FfmpegProgressParser
{
	private static readonly Regex ProgressRegex = new Regex(
		@"frame=\s*(\d+)\s+" +
		@"fps=\s*([\d\.]+)\s+" +
		@"q=\s*([\d\.]+)\s+" +
		@"size=\s*(\d+)KiB\s+" +
		@"time=(\d+:\d+:\d+\.\d+)\s+" +
		@"bitrate=\s*([\d\.]+)kbits/s\s+" +
		@"speed=\s*([\d\.]+)x\s+" +
		@"elapsed=(\d+:\d+:\d+\.\d+)",
		RegexOptions.Compiled | RegexOptions.CultureInvariant
	);

	public static EncodingProgress Parse(string input)
	{
		if (string.IsNullOrWhiteSpace(input))
			return null;

		var match = ProgressRegex.Match(input);
		if (!match.Success)
			return null;

		return new EncodingProgress(
			frame: int.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture),
			fps: double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture),
			quality: double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture),
			sizeKiB: long.Parse(match.Groups[4].Value, CultureInfo.InvariantCulture),
			time: TimeSpan.Parse(match.Groups[5].Value, CultureInfo.InvariantCulture),
			bitrateKbps: double.Parse(match.Groups[6].Value, CultureInfo.InvariantCulture),
			speed: double.Parse(match.Groups[7].Value, CultureInfo.InvariantCulture),
			elapsed: TimeSpan.Parse(match.Groups[8].Value, CultureInfo.InvariantCulture)
		);
	}
}
