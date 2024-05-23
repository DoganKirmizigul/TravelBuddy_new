using CleanArchitecture.Core.DTOs.Hotel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.DTOs.Rental
{
    

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Accessibility
    {
        public string fuel_policy { get; set; }
        public string pick_up_location { get; set; }
        public string transmission { get; set; }
        public string supplier_rating { get; set; }
    }

    public class Badge
    {
        public string variation { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string greenVehicle { get; set; }
    }

    public class Category
    {
        public decimal? count { get; set; }
        public string name { get; set; }
        public string nameWithCount { get; set; }
        public string id { get; set; }
    }

    public class Content
    {
        public List<Item> items { get; set; }
        public Filters filters { get; set; }
        public object dsaBanner { get; set; }
        public object discountBanner { get; set; }
        public string label { get; set; }
        public string contentType { get; set; }
        public Supplier supplier { get; set; }
        public List<Badge> badges { get; set; }
    }

    public class Data
    {
        public bool is_genius_location { get; set; }
        public Meta meta { get; set; }
        public object discount_banner { get; set; }
        public string search_key { get; set; }
        public string provider { get; set; }
        public Content content { get; set; }
        public List<Filter> filter { get; set; }
        public List<Sort> sort { get; set; }
        public string title { get; set; }
        public List<SearchResult> search_results { get; set; }
        public string type { get; set; }
        public decimal? count { get; set; }
    }

    public class DistanceAllowed
    {
        public decimal? is_km { get; set; }
        public object value { get; set; }
        public object per_duration { get; set; }
        public decimal? is_unlimited { get; set; }
    }

    public class Dropoff
    {
        public string country_code { get; set; }
        public string location_id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string longitude { get; set; }
        public string location_type { get; set; }
        public string address { get; set; }
        public string icon { get; set; }
        public string latitude { get; set; }
        public string city { get; set; }
    }

    public class FeeBreakdown
    {
        public List<KnownFee> known_fees { get; set; }
        public FuelPolicy fuel_policy { get; set; }
    }

    public class FeeInfo
    {
        public string currency { get; set; }
        public decimal? fee { get; set; }
        public decimal? tax { get; set; }
        public string type { get; set; }
    }

    public class Filter
    {
        public List<Category> categories { get; set; }
        public Layout layout { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public string title { get; set; }
    }

    public class Filters
    {
        public string countLabel { get; set; }
    }

    public class FuelPolicy
    {
        public decimal? amount { get; set; }
        public string type { get; set; }
        public string currency { get; set; }
    }

    public class Item
    {
        public decimal? positionInList { get; set; }
        public Content content { get; set; }
        public string type { get; set; }
    }

    public class KnownFee
    {
        public decimal? is_always_payable { get; set; }
        public decimal? is_tax_included { get; set; }
        public DistanceAllowed distance_allowed { get; set; }
        public double? amount { get; set; }
        public double? max_amount { get; set; }
        public string currency { get; set; }
        public double? min_amount { get; set; }
        public string type { get; set; }
    }

    public class Layout
    {
        public decimal? collapsed_count { get; set; }
        public string layout_type { get; set; }
        public string is_collapsable { get; set; }
        public string is_collapsed { get; set; }
    }

    public class LocalisedRating
    {
        public double rawValue { get; set; }
        public string displayValue { get; set; }
    }

    public class Meta
    {
        public decimal? response_code { get; set; }
    }

    public class Pickup
    {
        public string longitude { get; set; }
        public string country { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string latitude { get; set; }
        public string address { get; set; }
        public string location_type { get; set; }
        public string icon { get; set; }
        public string country_code { get; set; }
        public string location_id { get; set; }
    }

    public class PricingInfo
    {
        public bool drive_away_price_is_approx { get; set; }
        public string pay_when { get; set; }
        public string base_currency { get; set; }
        public double price { get; set; }
        public decimal? quote_allowed { get; set; }
        public double drive_away_price { get; set; }
        public string currency { get; set; }
        public double base_deposit { get; set; }
        public object drive_away_price_before { get; set; }
        public FeeBreakdown fee_breakdown { get; set; }
        public double base_price { get; set; }
        public double deposit { get; set; }
        public decimal? discount { get; set; }
    }

    public class Rating
    {
        public string average { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public LocalisedRating localisedRating { get; set; }
    }

    public class RatingInfo
    {
        public double average { get; set; }
        public decimal? pickup_time { get; set; }
        public double condition { get; set; }
        public double dropoff_time { get; set; }
        public string average_text { get; set; }
        public double cleanliness { get; set; }
        public decimal? no_of_ratings { get; set; }
        public double location { get; set; }
        public double efficiency { get; set; }
        public double value_for_money { get; set; }
    }

    public class RentalSearchResponse
    {
        public Data data { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }

    public class RouteInfo
    {
        public Pickup pickup { get; set; }
        public Dropoff dropoff { get; set; }
    }

    public class SearchResult
    {
        public VehicleInfo vehicle_info { get; set; }
        public Accessibility accessibility { get; set; }
        public RouteInfo route_info { get; set; }
        public RatingInfo rating_info { get; set; }
        public FeeInfo fee_info { get; set; }
        public string forward_url { get; set; }
        public PricingInfo pricing_info { get; set; }
        public List<object> applied_discount_types { get; set; }
        public Content content { get; set; }
        public SupplierInfo supplier_info { get; set; }
        public string pay_when_text { get; set; }
        public List<string> freebies { get; set; }
    }

    public class Sort
    {
        public string name { get; set; }
        public string identifier { get; set; }
        public string title_tag { get; set; }
    }

    public class Suitcases
    {
        public string small { get; set; }
        public string big { get; set; }
    }

    public class Supplier
    {
        public Rating rating { get; set; }
        public string imageUrl { get; set; }
        public string name { get; set; }
    }

    public class SupplierInfo
    {
        public string name { get; set; }
        public string longitude { get; set; }
        public string address { get; set; }
        public string location_type { get; set; }
        public string latitude { get; set; }
        public bool may_require_credit_card_guarantee { get; set; }
        public string logo_url { get; set; }
        public string dropoff_instructions { get; set; }
        public string pickup_instructions { get; set; }
    }

    public class VehicleInfo
    {
        public decimal? cma_compliant { get; set; }
        public string fuel_policy { get; set; }
        public string fuel_policy_description { get; set; }
        public string doors { get; set; }
        public string v_id { get; set; }
        public string insurance_package { get; set; }
        public string image_thumbnail_url { get; set; }
        public string seats { get; set; }
        public string fuel_type { get; set; }
        public decimal? free_cancellation { get; set; }
        public decimal? unlimited_mileage { get; set; }
        public string transmission { get; set; }
        public object special_offer_text { get; set; }
        public string mileage { get; set; }
        public decimal? airbags { get; set; }
        public string group { get; set; }
        public Suitcases suitcases { get; set; }
        public string image_url { get; set; }
        public decimal? aircon { get; set; }
        public string label { get; set; }
        public string v_name { get; set; }
    }


}
