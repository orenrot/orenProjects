package entity;

import java.util.ArrayList;

public class Resturant extends Place {
	protected Integer StarRating;
	protected String kitchenStyles;
	public Resturant(Integer placeId, String nameOfPlace, String description, Integer urlLandmark, String priceLevel,
			String city,Integer starRating, String kitchenStyles) {
		super(placeId, nameOfPlace, description, urlLandmark, priceLevel,city);
		StarRating = starRating;
		this.kitchenStyles = kitchenStyles;
	}
	public Integer getStarRating() {
		return StarRating;
	}
	public void setStarRating(Integer starRating) {
		StarRating = starRating;
	}
	public String getKitchenStyles() {
		return kitchenStyles;
	}
	public void setKitchenStyles(String kitchenStyles) {
		this.kitchenStyles = kitchenStyles;
	}
	@Override
	public String toString() {
		return "Resturant [StarRating=" + StarRating + ", kitchenStyles=" + kitchenStyles + ", toString()="
				+ super.toString() + "]";
	}
	
}
