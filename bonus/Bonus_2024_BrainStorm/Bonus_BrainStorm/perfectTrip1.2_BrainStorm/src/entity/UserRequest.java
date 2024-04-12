package entity;

public class UserRequest {
	private Integer userId;
	private Integer tripId;
	private String describe;
	private Integer status;
	private String email;
	public UserRequest(Integer userId, Integer tripId, String describe, Integer status, String email) {
		super();
		this.userId = userId;
		this.tripId = tripId;
		this.describe = describe;
		this.status = status;
		this.email = email;
	}
	public UserRequest(Integer userId, Integer tripId, String describe, String email) {
		super();
		this.userId = userId;
		this.tripId = tripId;
		this.describe = describe;
		this.setEmail(email);
	}
	public UserRequest(Integer userId, Integer tripId, String describe) {
		super();
		this.userId = userId;
		this.tripId = tripId;
		this.describe = describe;
	}
	public UserRequest(int userId, int tripId, String describe) {
		// TODO Auto-generated constructor stub
		super();
		this.userId = userId;
		this.tripId = tripId;
		this.describe = describe;
	}

	public Integer getUserId() {
		return userId;
	}
	public void setUserId(Integer userId) {
		this.userId = userId;
	}
	public Integer getTripId() {
		return tripId;
	}
	public void setTripId(Integer tripId) {
		this.tripId = tripId;
	}
	public String getDescribe() {
		return describe;
	}
	public void setDescribe(String describe) {
		this.describe = describe;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	@Override
	public String toString() {
		return "UserRequest [userId=" + userId + ", tripId=" + tripId + ", describe=" + describe + ", email=" + email
				+ "]";
	}
	
}
