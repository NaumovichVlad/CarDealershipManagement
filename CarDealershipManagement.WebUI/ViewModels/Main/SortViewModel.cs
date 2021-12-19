namespace CarDealershipManagement.WebUI.ViewModels.Main
{
    public enum CarSortState
    {
        No,
        BrandNameAsc,
        BrandNameDesc,
        ManufacturerNameAsc,
        ManufacturerNameDesc,
        PriceAsc,
        PriceDesc
    }
    public class SortViewModel
    {
        public CarSortState BrandSortParam { get; set; }
        public CarSortState ManufacturerNameSortParam { get; set; }
        public CarSortState PriceSortParam { get; set; }
        public CarSortState CurrentSort { get; set; }

        public SortViewModel(CarSortState sortOrder)
        {
            BrandSortParam = sortOrder == CarSortState.BrandNameAsc ? CarSortState.BrandNameDesc : CarSortState.BrandNameAsc;
            ManufacturerNameSortParam = sortOrder == CarSortState.ManufacturerNameAsc ? CarSortState.ManufacturerNameDesc : CarSortState.ManufacturerNameAsc;
            PriceSortParam = sortOrder == CarSortState.PriceAsc ? CarSortState.PriceDesc : CarSortState.PriceAsc;
            CurrentSort = sortOrder;
        }


    }
}
