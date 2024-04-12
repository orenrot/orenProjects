package entity;

public class TravelCreator extends User {
	protected String phoneNumber;
		public TravelCreator(Integer userId, String firstName, String lastName, String email,String pass,String phoneNum) {
		super(userId, firstName, lastName, email,pass);
		this.phoneNumber=phoneNum;
	}
		public void DoTrip()//create Trip
		{
			
		}
}
