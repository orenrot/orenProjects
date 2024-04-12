package entity;

import java.util.ArrayList;

public class TripPlace {
	private Integer TripNumber;
	private ArrayList<Integer> placeInTrip;
	public TripPlace() {
		super();
		placeInTrip= new ArrayList<Integer>();
	}
	public TripPlace(Integer tripNumber, ArrayList<Integer> placeInTrip) {
		super();
		TripNumber = tripNumber;
		this.placeInTrip = placeInTrip;
	}
	public boolean AddPlace(Integer newPlace)
	{
		return placeInTrip.add(newPlace);//true if success false if dont
	}
	public Integer getTripNumber() {
		return TripNumber;
	}
	public void setTripNumber(Integer tripNumber) {
		TripNumber = tripNumber;
	}
	public ArrayList<Integer> getPlaceInTrip() {
		return placeInTrip;
	}
	public void setPlaceInTrip(ArrayList<Integer> placeInTrip) {
		this.placeInTrip = placeInTrip;
	}
	

}
