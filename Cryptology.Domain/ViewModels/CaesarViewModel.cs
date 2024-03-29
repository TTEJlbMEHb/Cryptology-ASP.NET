﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptology.Domain.ViewModels
{
    public class CaesarViewModel
    {
        public int Key { get; set; }
        public string Text { get; set; }
        public string? Encrypted { get; set; }
        public string? Decrypted { get; set; }
        public IFormFile? OpenFile { get; set; }
        public IFormFile? SaveFile { get; set; }
        public List<string> BruteForced { get; set; } = new List<string>();
        public Dictionary<char, int>? FrequencyTable { get; set; } = new Dictionary<char, int>();
        public IFormFile? InputImage { get; set; }
        public IFormFile? EncryptedImage { get; set; }
        public IFormFile? DecryptedImage { get; set; }
    }
}
