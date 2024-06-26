﻿using Cryptology.BLL;
using Cryptology.Domain.Entity;
using Cryptology.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cryptology.Controllers
{
    public class CyphersController : Controller
    {
        private readonly CaesarService _caesarService;
        private readonly TrithemiusService _trithemiusService;
        private readonly GammaService _gammaService;
        private readonly KnapsackService _knapsackService;
        private readonly RsaService _rsaService;

        public CyphersController(CaesarService caesarService, TrithemiusService trithemiusService,
            GammaService gammaService, KnapsackService knapsackService, RsaService rsaService)
        {
            _caesarService = caesarService;
            _trithemiusService = trithemiusService;
            _gammaService = gammaService;
            _knapsackService = knapsackService;
            _rsaService = rsaService;
        }

        public async Task<IActionResult> CaesarCypher()
        {
            return View(new CaesarViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CaesarCypher(CaesarViewModel caesar, string action)
        {
            if (action == "Encrypt")
            {
                var encryptResponse = await _caesarService.Encrypt(caesar);

                if (encryptResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = encryptResponse.Description;
                    TempData["ResponseStatus"] = encryptResponse.StatusCode.ToString();
                    return View("CaesarCypher", caesar);
                }
                else
                {
                    TempData["AlertMessage"] = encryptResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "Decrypt")
            {
                var decryptResponse = await _caesarService.Decrypt(caesar);

                if (decryptResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = decryptResponse.Description;
                    TempData["ResponseStatus"] = decryptResponse.StatusCode.ToString();
                    return View("CaesarCypher", caesar);
                }
                else
                {
                    TempData["AlertMessage"] = decryptResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "BruteForce")
            {
                var bruteForceResponse = await _caesarService.BruteForce(caesar);

                if (bruteForceResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = bruteForceResponse.Description;
                    TempData["ResponseStatus"] = bruteForceResponse.StatusCode.ToString();
                    return View("CaesarCypher", caesar);
                }
                else
                {
                    TempData["AlertMessage"] = bruteForceResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "OpenFile")
            {
                var openfileResponse = await _caesarService.OpenFromFile(caesar.OpenFile);

                if (openfileResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = openfileResponse.Description;
                    TempData["ResponseStatus"] = openfileResponse.StatusCode.ToString();
                    return View("CaesarCypher", openfileResponse.Data);
                }
                else
                {
                    TempData["AlertMessage"] = openfileResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "SaveFile")
            {
                var saveFileResponse = await _caesarService.SaveToFile(caesar);

                if (saveFileResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = saveFileResponse.Description;
                    TempData["ResponseStatus"] = saveFileResponse.StatusCode.ToString();
                    string filePath = "path_to_save_file.txt";
                    byte[] fileContents = await System.IO.File.ReadAllBytesAsync(filePath);
                    return File(fileContents, "text/plain", $"{DateTime.UtcNow} - result.txt");
                }
                else
                {
                    TempData["AlertMessage"] = saveFileResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "FrequencyTable")
            {
                var frequencyTableResponse = await _caesarService.FrequencyTable(caesar);

                if (frequencyTableResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = frequencyTableResponse.Description;
                    TempData["ResponseStatus"] = frequencyTableResponse.StatusCode.ToString();
                    return View("CaesarCypher", frequencyTableResponse.Data);
                }
                else
                {
                    TempData["AlertMessage"] = frequencyTableResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "EncryptImage")
            {
                var encryptImageResponse = await _caesarService.EncryptImage(caesar);

                if (encryptImageResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["ImageAlertMessage"] = encryptImageResponse.Description;
                    TempData["ImageResponseStatus"] = encryptImageResponse.StatusCode.ToString();
                    return View("CaesarCypher", encryptImageResponse.Data);
                }
                else
                {
                    TempData["AlertMessage"] = encryptImageResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "DecryptImage")
            {
                var decryptImageResponse = await _caesarService.DecryptImage(caesar);

                if (decryptImageResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["ImageAlertMessage"] = decryptImageResponse.Description;
                    TempData["ImageResponseStatus"] = decryptImageResponse.StatusCode.ToString();
                    return View("CaesarCypher", decryptImageResponse.Data);
                }
                else
                {
                    TempData["AlertMessage"] = decryptImageResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }

            return View(caesar);
        }

        public async Task<IActionResult> TrithemiusCypher()
        {
            return View(new TrithemiusViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> TrithemiusCypher(TrithemiusViewModel trithemius, string action)
        {
            if (action == "Encrypt")
            {
                var encryptResponse = await _trithemiusService.Encrypt(trithemius);

                if (encryptResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return View("TrithemiusCypher", trithemius);
                }
                else
                {
                    TempData["AlertMessage"] = encryptResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "Decrypt")
            {
                var decryptResponse = await _trithemiusService.Decrypt(trithemius);

                if (decryptResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return View("TrithemiusCypher", trithemius);
                }
                else
                {
                    TempData["AlertMessage"] = decryptResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "BruteForce")
            {
                var bruteForceResponse = await _trithemiusService.BruteForce(trithemius);

                if (bruteForceResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return View("TrithemiusCypher", trithemius);
                }
                else
                {
                    TempData["AlertMessage"] = bruteForceResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "OpenFile")
            {
                var openfileResponse = await _trithemiusService.OpenFromFile(trithemius.OpenFile);

                if (openfileResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = openfileResponse.Description;
                    TempData["ResponseStatus"] = openfileResponse.StatusCode.ToString();
                    return View("TrithemiusCypher", openfileResponse.Data);
                }
                else
                {
                    TempData["AlertMessage"] = openfileResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "SaveFile")
            {
                var saveFileResponse = await _trithemiusService.SaveToFile(trithemius);

                if (saveFileResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = saveFileResponse.Description;
                    TempData["ResponseStatus"] = saveFileResponse.StatusCode.ToString();
                    string filePath = "path_to_save_file.txt";
                    byte[] fileContents = await System.IO.File.ReadAllBytesAsync(filePath);
                    return File(fileContents, "text/plain", $"{DateTime.UtcNow} - result.txt");
                }
                else
                {
                    TempData["AlertMessage"] = saveFileResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "FrequencyTable")
            {
                var frequencyTableResponse = await _trithemiusService.FrequencyTable(trithemius);

                if (frequencyTableResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = frequencyTableResponse.Description;
                    TempData["ResponseStatus"] = frequencyTableResponse.StatusCode.ToString();
                    return View("TrithemiusCypher", frequencyTableResponse.Data);
                }
                else
                {
                    TempData["AlertMessage"] = frequencyTableResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            return View(trithemius);
        }

        public async Task<IActionResult> GammaCypher()
        {
            return View(new GammaViewModel());
        }
        
        [HttpPost]
        public async Task<IActionResult> GammaCypher(GammaViewModel gammaViewModel, string action)
        {
            if (action == "Encrypt")
            {
                var encryptResponse = await _gammaService.Encrypt(gammaViewModel);

                if (encryptResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return View("GammaCypher", gammaViewModel);
                }
                else
                {
                    TempData["AlertMessage"] = encryptResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "Decrypt")
            {
                var decryptResponse = await _gammaService.Decrypt(gammaViewModel);

                if (decryptResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return View("GammaCypher", gammaViewModel);
                }
                else
                {
                    TempData["AlertMessage"] = decryptResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "OpenFile")
            {
                var openfileResponse = await _gammaService.OpenFromFile(gammaViewModel.OpenFile);
            
                if (openfileResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = openfileResponse.Description;
                    TempData["ResponseStatus"] = openfileResponse.StatusCode.ToString();
                    return View("GammaCypher", openfileResponse.Data);
                }
                else
                {
                    TempData["AlertMessage"] = openfileResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "SaveFile")
            {
                var saveFileResponse = await _gammaService.SaveToFile(gammaViewModel);
            
                if (saveFileResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = saveFileResponse.Description;
                    TempData["ResponseStatus"] = saveFileResponse.StatusCode.ToString();
                    string filePath = "path_to_save_file.txt";
                    byte[] fileContents = await System.IO.File.ReadAllBytesAsync(filePath);
                    return File(fileContents, "text/plain", $"{DateTime.UtcNow} - result.txt");
                }
                else
                {
                    TempData["AlertMessage"] = saveFileResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "FrequencyTable")
            {
                var frequencyTableResponse = await _gammaService.FrequencyTable(gammaViewModel);
            
                if (frequencyTableResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = frequencyTableResponse.Description;
                    TempData["ResponseStatus"] = frequencyTableResponse.StatusCode.ToString();
                    return View("GammaCypher", frequencyTableResponse.Data);
                }
                else
                {
                    TempData["AlertMessage"] = frequencyTableResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            
            return View(gammaViewModel);
        }

        public async Task<IActionResult> KnapsackCypher()
        {
            return View(new KnapsackViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> KnapsackCypher(KnapsackViewModel knapsackViewModel, string action)
        {
            if (action == "Resolve")
            {
                var encryptResponse = await _knapsackService.Encrypt(knapsackViewModel);
                var decryptResponse = await _knapsackService.Decrypt(encryptResponse.Data);

                if (encryptResponse.StatusCode == Domain.Enum.StatusCode.OK &&
                    decryptResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return View("KnapsackCypher", knapsackViewModel);
                }
                else
                {
                    TempData["AlertMessage"] = encryptResponse.Description;
                    TempData["AlertMessage"] = decryptResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "OpenFile")
            {
                var openfileResponse = await _knapsackService.OpenFromFile(knapsackViewModel.OpenFile);

                if (openfileResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = openfileResponse.Description;
                    TempData["ResponseStatus"] = openfileResponse.StatusCode.ToString();
                    return View("KnapsackCypher", openfileResponse.Data);
                }
                else
                {
                    TempData["AlertMessage"] = openfileResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "SaveFile")
            {
                var saveFileResponse = await _knapsackService.SaveToFile(knapsackViewModel);

                if (saveFileResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = saveFileResponse.Description;
                    TempData["ResponseStatus"] = saveFileResponse.StatusCode.ToString();
                    string filePath = "path_to_save_file.txt";
                    byte[] fileContents = await System.IO.File.ReadAllBytesAsync(filePath);
                    return File(fileContents, "text/plain", $"{DateTime.UtcNow} - result.txt");
                }
                else
                {
                    TempData["AlertMessage"] = saveFileResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "FrequencyTable")
            {
                var frequencyTableResponse = await _knapsackService.FrequencyTable(knapsackViewModel);

                if (frequencyTableResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = frequencyTableResponse.Description;
                    TempData["ResponseStatus"] = frequencyTableResponse.StatusCode.ToString();
                    return View("KnapsackCypher", frequencyTableResponse.Data);
                }
                else
                {
                    TempData["AlertMessage"] = frequencyTableResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }

            return View(knapsackViewModel);
        }

        public async Task<IActionResult> RsaCypher()
        {
            return View(new RsaViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> RsaCypher(RsaViewModel rsaViewModel, string action)
        {
            if (action == "Encrypt")
            {
                var encryptResponse = await _rsaService.Encrypt(rsaViewModel);

                if (encryptResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return View("RsaCypher", rsaViewModel);
                }
                else
                {
                    TempData["AlertMessage"] = encryptResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "Decrypt")
            {
                var decryptResponse = await _rsaService.Decrypt(rsaViewModel);

                if (decryptResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return View("RsaCypher", rsaViewModel);
                }
                else
                {
                    TempData["AlertMessage"] = decryptResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "OpenFile")
            {
                var openfileResponse = await _rsaService.OpenFromFile(rsaViewModel.OpenFile);

                if (openfileResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = openfileResponse.Description;
                    TempData["ResponseStatus"] = openfileResponse.StatusCode.ToString();
                    return View("RsaCypher", openfileResponse.Data);
                }
                else
                {
                    TempData["AlertMessage"] = openfileResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "SaveFile")
            {
                var saveFileResponse = await _rsaService.SaveToFile(rsaViewModel);

                if (saveFileResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = saveFileResponse.Description;
                    TempData["ResponseStatus"] = saveFileResponse.StatusCode.ToString();
                    string filePath = "path_to_save_file.txt";
                    byte[] fileContents = await System.IO.File.ReadAllBytesAsync(filePath);
                    return File(fileContents, "text/plain", $"{DateTime.UtcNow} - result.txt");
                }
                else
                {
                    TempData["AlertMessage"] = saveFileResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }
            else if (action == "FrequencyTable")
            {
                var frequencyTableResponse = await _rsaService.FrequencyTable(rsaViewModel);

                if (frequencyTableResponse.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["AlertMessage"] = frequencyTableResponse.Description;
                    TempData["ResponseStatus"] = frequencyTableResponse.StatusCode.ToString();
                    return View("RsaCypher", frequencyTableResponse.Data);
                }
                else
                {
                    TempData["AlertMessage"] = frequencyTableResponse.Description;
                    TempData["ResponseStatus"] = "Error";
                }
            }

            return View(rsaViewModel);
        }
    }
}
