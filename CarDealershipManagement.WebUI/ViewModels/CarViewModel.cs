﻿namespace CarDealershipManagement.WebUI.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ManufacturerName { get; set; }
        public string RegistrationNumber { get; set; }
        public string BodyTypeNumber { get; set; }
        public string EngineNumber { get; set; }
        public byte[] Picture { get; set; }
        public double Price { get; set; }
    }
}
