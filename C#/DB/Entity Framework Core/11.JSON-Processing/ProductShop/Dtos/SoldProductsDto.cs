﻿namespace ProductShop.Dtos
{
    public class SoldProductsDto
    {
        public int Count { get; set; }

        public ProductDetailsDto[] Products { get; set; }
    }
}
