﻿using RwsMoraviaHomework.Utils;

namespace Tests.Utils
{
    [TestFixture]
    public class FileExtentionUtilsTests
    {
        [TestCase("C://file.txt", ".txt")]
        [TestCase("C://file.json", ".json")]
        [TestCase("./../file.xml", ".xml")]
        public void GetFileExtention_ValidFileName_ReturnsExtention(string file, string expectedExtention)
        {
            var result = FileExtentionUtils.GetFileExtention(file);

            Assert.That(result, Is.EqualTo(expectedExtention));
        }

        [TestCase("C://file")]
        [TestCase("")]
        [TestCase("   ")]
        public void GetFileExtention_InalidFile_ThrowsArgumentException(string file)
        {
            Assert.Throws<ArgumentException>(() => FileExtentionUtils.GetFileExtention(file), message: "Invalid source file, unable to get file extention.");
        }
    }
}
