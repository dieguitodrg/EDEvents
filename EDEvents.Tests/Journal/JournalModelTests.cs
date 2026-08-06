using EDCrew;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace EDEvents.Tests.Journal
{
    public class JournalModelTests
    {
        private static readonly Lazy<string> SamplesDir = new Lazy<string>(() =>
        {
            var bin = AppDomain.CurrentDomain.BaseDirectory;
            var repo = Path.GetFullPath(Path.Combine(bin, "..", "..", "..", ".."));
            return Path.Combine(repo, "tools", "JournalSamples");
        });

        public static TheoryData<string> SampleFiles()
        {
            var data = new TheoryData<string>();
            foreach (var f in Directory.GetFiles(SamplesDir.Value, "*.json").OrderBy(x => x))
            {
                data.Add(Path.GetFileName(f));
            }
            return data;
        }

        [Theory]
        [MemberData(nameof(SampleFiles))]
        public void ReadJsonResuelveLaClaseTipada(string file)
        {
            var json = File.ReadAllText(Path.Combine(SamplesDir.Value, file));
            var expected = Regex.Match(json, "\"event\"\\s*:\\s*\"([^\"]+)\"").Groups[1].Value;

            var journal = Reader.ReadJson(json);

            Assert.NotNull(journal);
            Assert.Equal(expected, journal.@event);
            Assert.Equal("Journal" + expected, journal.GetType().Name);
        }
    }
}
