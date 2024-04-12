package entity;

import java.util.Objects;

public class Place {
	protected Integer placeId;
	protected String priceLevel;
	protected String nameOfPlace;
	protected String description;
	protected String City;//the most it will be both
	protected Integer countryNumber;//when we added new
	protected Integer UrlLandmark;
	public Place(Integer placeId, String nameOfPlace, String description, Integer urlLandmark, String priceLevel,
			String city) {
		super();
		this.placeId = placeId;
		this.priceLevel = priceLevel;
		this.nameOfPlace = nameOfPlace;
		this.description = description;
		City = city;
		UrlLandmark = urlLandmark;
	}
	public Place(Integer id, String nameOfPlace, String describe, Integer urlMark, String priceLevel,
			String cityName, Integer countryCode) {
		this.placeId=id;
		this.nameOfPlace=nameOfPlace;
		this.description=describe;
		this.UrlLandmark=urlMark;
		this.priceLevel=priceLevel;
		this.City=cityName;
		this.countryNumber=countryCode;
		//System.out.println("hiii");
	}
	public Integer getPlaceId() {
		return placeId;
	}
	public void setPlaceId(Integer placeId) {
		this.placeId = placeId;
	}
	public String getPriceLevel() {
		return priceLevel;
	}
	public void setPriceLevel(String priceLevel) {
		this.priceLevel = priceLevel;
	}
	public String getNameOfPlace() {
		return nameOfPlace;
	}
	public void setNameOfPlace(String nameOfPlace) {
		this.nameOfPlace = nameOfPlace;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public String getCity() {
		return City;
	}
	public void setCity(String city) {
		City = city;
	}
	public Integer getUrlLandmark() {
		return UrlLandmark;
	}
	public void setUrlLandmark(Integer urlLandmark) {
		UrlLandmark = urlLandmark;
	}
	public Integer getCountryNumber() {
		return countryNumber;
	}
	public void setCountryNumber(Integer countryNumber) {
		this.countryNumber = countryNumber;
	}
	
	@Override
	public int hashCode() {
		return Objects.hash(City, UrlLandmark, description, nameOfPlace, placeId, priceLevel);
	}
	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Place other = (Place) obj;
		return Objects.equals(City, other.City) && Objects.equals(UrlLandmark, other.UrlLandmark)
				&& Objects.equals(description, other.description) && Objects.equals(nameOfPlace, other.nameOfPlace)
				&& Objects.equals(placeId, other.placeId) && Objects.equals(priceLevel, other.priceLevel);
	}
	@Override
	public String toString() {
		return "Place [placeId=" + placeId + ", priceLevel=" + priceLevel + ", nameOfPlace=" + nameOfPlace
				+ ", description=" + description + ", City=" + City + ", UrlLandmark=" + UrlLandmark + "]";
	}
	
}
