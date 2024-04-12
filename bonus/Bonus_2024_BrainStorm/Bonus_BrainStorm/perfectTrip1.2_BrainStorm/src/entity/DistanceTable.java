package entity;

public class DistanceTable {
	protected Integer placeFrom;
	protected Integer placeTo;
	protected Integer distance;
//	
	public DistanceTable(Integer placeFrom, Integer placeTo, Integer distance) {
		super();
		this.placeFrom = placeFrom;
		this.placeTo = placeTo;
		this.distance = distance;
	}
	public Integer getPlaceFrom() {
		return placeFrom;
	}
	public void setPlaceFrom(Integer placeFrom) {
		this.placeFrom = placeFrom;
	}
	public Integer getPlaceTo() {
		return placeTo;
	}
	public void setPlaceTo(Integer placeTo) {
		this.placeTo = placeTo;
	}
	public Integer getDistance() {
		return distance;
	}
	public void setDistance(Integer distance) {
		this.distance = distance;
	}
	@Override
	public String toString() {
		return "DistanceTable [placeFrom=" + placeFrom + ", placeTo=" + placeTo + ", distance=" + distance + "]";
	}
}
