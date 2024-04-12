package entity;

import java.util.ArrayList;

public class Hotel extends Place {
	protected Integer StarRating;
	public Hotel(Integer placeId, String nameOfPlace, String description, Integer urlLandmark, String priceLevel,
			String city, Integer starRating) {
		super(placeId, nameOfPlace, description, urlLandmark, priceLevel,city);
		StarRating = starRating;
	}
	public Integer getStarRating() {
		return StarRating;
	}
	public void setStarRating(Integer starRating) {
		StarRating = starRating;
	}
	
}
