
namespace HotelReservation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class PriceCalculator
    {
        public static decimal GetTotalPrice(
            decimal pricePerDay, 
            int numberOfDays,
            Season season,
            DiscountType discountType)
        {
            decimal discount = (decimal)discountType / 100.0m;
            decimal priceBeforreDiscount = (pricePerDay * numberOfDays * (int)season);
            decimal discountPrice = priceBeforreDiscount * discount;
            decimal totalPrice = priceBeforreDiscount - discountPrice;

            return totalPrice;
        }
    }
}
