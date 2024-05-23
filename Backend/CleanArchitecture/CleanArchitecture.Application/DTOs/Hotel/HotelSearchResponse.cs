using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.DTOs.Hotel
{
   

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AllInclusiveAmount
    {
        public string currency { get; set; }
        public string amount_rounded { get; set; }
        public double value { get; set; }
        public string amount_unrounded { get; set; }
    }

    public class Amount
    {
        public decimal? value { get; set; }
        public string currency { get; set; }
    }

    public class Badge
    {
        public string id { get; set; }
        public string text { get; set; }
        public string badge_variant { get; set; }
    }

    public class Base
    {
        public decimal? base_amount { get; set; }
        public string kind { get; set; }
    }

    public class Benefit
    {
        public object icon { get; set; }
        public string badge_variant { get; set; }
        public string identifier { get; set; }
        public string details { get; set; }
        public string name { get; set; }
        public string kind { get; set; }
    }

    public class Bwallet
    {
        public decimal? hotel_eligibility { get; set; }
    }

    public class ChargesDetails
    {
        public string translated_copy { get; set; }
        public Amount amount { get; set; }
        public string mode { get; set; }
    }

    public class Checkin
    {
        public string until { get; set; }
        public string from { get; set; }
    }

    public class Checkout
    {
        public string from { get; set; }
        public string until { get; set; }
    }

    public class CompositePriceBreakdown
    {
        public GrossAmountPerNight gross_amount_per_night { get; set; }
        public IncludedTaxesAndChargesAmount included_taxes_and_charges_amount { get; set; }
        public List<ProductPriceBreakdown> product_price_breakdowns { get; set; }
        public NetAmount net_amount { get; set; }
        public DiscountedAmount discounted_amount { get; set; }
        public List<Benefit> benefits { get; set; }
        public ChargesDetails charges_details { get; set; }
        public GrossAmountHotelCurrency gross_amount_hotel_currency { get; set; }
        public StrikethroughAmount strikethrough_amount { get; set; }
        public StrikethroughAmountPerNight strikethrough_amount_per_night { get; set; }
        public ExcludedAmount excluded_amount { get; set; }
        public GrossAmount gross_amount { get; set; }
        public List<Item> items { get; set; }
        public AllInclusiveAmount all_inclusive_amount { get; set; }
    }

    public class DiscountedAmount
    {
        public string currency { get; set; }
        public string amount_rounded { get; set; }
        public double value { get; set; }
        public string amount_unrounded { get; set; }
    }

    public class Distance
    {
        public object icon_set { get; set; }
        public string icon_name { get; set; }
        public string text { get; set; }
    }

    public class ExcludedAmount
    {
        public double value { get; set; }
        public string amount_unrounded { get; set; }
        public string currency { get; set; }
        public string amount_rounded { get; set; }
    }

    public class GrossAmount
    {
        public string amount_unrounded { get; set; }
        public double value { get; set; }
        public string currency { get; set; }
        public string amount_rounded { get; set; }
    }

    public class GrossAmountHotelCurrency
    {
        public double value { get; set; }
        public string amount_unrounded { get; set; }
        public string amount_rounded { get; set; }
        public string currency { get; set; }
    }

    public class GrossAmountPerNight
    {
        public string amount_unrounded { get; set; }
        public double value { get; set; }
        public string amount_rounded { get; set; }
        public string currency { get; set; }
    }

    public class IncludedTaxesAndChargesAmount
    {
        public string amount_rounded { get; set; }
        public string currency { get; set; }
        public string amount_unrounded { get; set; }
        public decimal? value { get; set; }
    }

    public class Item
    {
        public string details { get; set; }
        public Base @base { get; set; }
        public string inclusion_type { get; set; }
        public ItemAmount item_amount { get; set; }
        public string name { get; set; }
        public string kind { get; set; }
        public string identifier { get; set; }
    }

    public class ItemAmount
    {
        public string amount_rounded { get; set; }
        public string currency { get; set; }
        public string amount_unrounded { get; set; }
        public double value { get; set; }
    }

    public class MapBoundingBox
    {
        public double sw_lat { get; set; }
        public double ne_lat { get; set; }
        public double ne_long { get; set; }
        public double sw_long { get; set; }
    }

    public class MatchingUnitsCommonConfig
    {
        public decimal? unit_type_id { get; set; }
        public object localized_area { get; set; }
    }

    public class MatchingUnitsConfiguration
    {
        public MatchingUnitsCommonConfig matching_units_common_config { get; set; }
    }

    public class NetAmount
    {
        public string currency { get; set; }
        public string amount_rounded { get; set; }
        public string amount_unrounded { get; set; }
        public double value { get; set; }
    }

    public class PriceBreakdown
    {
        public double all_inclusive_price { get; set; }
        public string gross_price { get; set; }
        public string currency { get; set; }
        public decimal? has_tax_exceptions { get; set; }
        public decimal? has_incalculable_charges { get; set; }
        public double sum_excluded_raw { get; set; }
        public decimal? has_fine_print_charges { get; set; }
    }

    public class ProductPriceBreakdown
    {
        public ChargesDetails charges_details { get; set; }
        public NetAmount net_amount { get; set; }
        public DiscountedAmount discounted_amount { get; set; }
        public List<Benefit> benefits { get; set; }
        public GrossAmountPerNight gross_amount_per_night { get; set; }
        public IncludedTaxesAndChargesAmount included_taxes_and_charges_amount { get; set; }
        public GrossAmountHotelCurrency gross_amount_hotel_currency { get; set; }
        public List<Item> items { get; set; }
        public AllInclusiveAmount all_inclusive_amount { get; set; }
        public GrossAmount gross_amount { get; set; }
        public ExcludedAmount excluded_amount { get; set; }
        public StrikethroughAmountPerNight strikethrough_amount_per_night { get; set; }
        public StrikethroughAmount strikethrough_amount { get; set; }
    }

    public class Result
    {
        public object selected_review_topic { get; set; }
        public string url { get; set; }
        public double? review_score { get; set; }
        public string default_language { get; set; }
        public string country_trans { get; set; }
        public decimal? is_beach_front { get; set; }
        public List<string> block_ids { get; set; }
        public string native_ad_id { get; set; }
        public PriceBreakdown price_breakdown { get; set; }
        public List<Distance> distances { get; set; }
        public string hotel_name_trans { get; set; }
        public string address { get; set; }
        public string is_geo_rate { get; set; }
        public MatchingUnitsConfiguration matching_units_configuration { get; set; }
        public string hotel_name { get; set; }
        public string hotel_facilities { get; set; }
        public string main_photo_url { get; set; }
        public decimal? soldout { get; set; }
        public decimal? district_id { get; set; }
        public string city { get; set; }
        public double min_total_price { get; set; }
        public decimal? main_photo_id { get; set; }
        public List<Badge> badges { get; set; }
        public string native_ads_tracking { get; set; }
        public string accommodation_type_name { get; set; }
        public decimal? children_not_allowed { get; set; }
        public object updated_checkout { get; set; }
        public string type { get; set; }
        public string address_trans { get; set; }
        public decimal? has_free_parking { get; set; }
        public decimal? is_free_cancellable { get; set; }
        public decimal? block_cribs_availability { get; set; }
        public Checkout checkout { get; set; }
        public string review_score_word { get; set; }
        public decimal? is_city_center { get; set; }
        public string city_in_trans { get; set; }
        public decimal? is_smart_deal { get; set; }
        public double mobile_discount_percentage { get; set; }
        public decimal? review_nr { get; set; }
        public string currency_code { get; set; }
        public string review_recommendation { get; set; }
        public string id { get; set; }
        public decimal? is_genius_deal { get; set; }
        public string zip { get; set; }
        public decimal? cc_required { get; set; }
        public string cc1 { get; set; }
        public decimal? @class { get; set; }
        public string timezone { get; set; }
        public string distance { get; set; }
        public decimal? accommodation_type { get; set; }
        public decimal? preferred { get; set; }
        public decimal? price_is_final { get; set; }
        public double latitude { get; set; }
        public decimal? hotel_id { get; set; }
        public decimal? extended { get; set; }
        public decimal? native_ads_cpc { get; set; }
        public decimal? wishlist_count { get; set; }
        public string districts { get; set; }
        public string city_trans { get; set; }
        public CompositePriceBreakdown composite_price_breakdown { get; set; }
        public decimal? class_is_estimated { get; set; }
        public decimal? ufi { get; set; }
        public decimal? property_cribs_availability { get; set; }
        public string city_name_en { get; set; }
        public decimal? is_mobile_deal { get; set; }
        public decimal? in_best_district { get; set; }
        public string unit_configuration_label { get; set; }
        public Bwallet bwallet { get; set; }
        public decimal? genius_discount_percentage { get; set; }
        public decimal? cant_book { get; set; }
        public object updated_checkin { get; set; }
        public string countrycode { get; set; }
        public decimal? preferred_plus { get; set; }
        public Checkin checkin { get; set; }
        public decimal? is_no_prepayment_block { get; set; }
        public string currencycode { get; set; }
        public decimal? hotel_has_vb_boost { get; set; }
        public decimal? hotel_include_breakfast { get; set; }
        public string default_wishlist_name { get; set; }
        public string district { get; set; }
        public double longitude { get; set; }
        public string max_photo_url { get; set; }
        public string max_1440_photo_url { get; set; }
    }

    public class RoomDistribution
    {
        public string adults { get; set; }
        public List<decimal?> children { get; set; }
    }

    public class HotelSearchResponse
    {
        public decimal? primary_count { get; set; }
        public decimal? count { get; set; }
        public decimal? total_count_with_filters { get; set; }
        public decimal? unfiltered_count { get; set; }
        public decimal? extended_count { get; set; }
        public decimal? unfiltered_primary_count { get; set; }
        public decimal? search_radius { get; set; }
        public List<Sort> sort { get; set; }
        public List<Result> result { get; set; }
        public string error { get; set; }
    }

    public class Sort
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class StrikethroughAmount
    {
        public string amount_rounded { get; set; }
        public string currency { get; set; }
        public string amount_unrounded { get; set; }
        public decimal? value { get; set; }
    }

    public class StrikethroughAmountPerNight
    {
        public string amount_unrounded { get; set; }
        public decimal? value { get; set; }
        public string currency { get; set; }
        public string amount_rounded { get; set; }
    }


}
