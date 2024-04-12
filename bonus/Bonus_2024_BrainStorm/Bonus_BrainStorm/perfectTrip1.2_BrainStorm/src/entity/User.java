package entity;

public class User {

	
		protected  Integer UserId;
		protected  String firstName;
		protected  String lastName;
		protected  String email;
		protected String password;
		public User(Integer userId, String firstName, String lastName, String email) {
			this.UserId = userId;
			this.firstName = firstName;
			this.lastName = lastName;
			this.email = email;
		}
	
		public User(Integer userId, String firstName, String lastName, String email,String pass) {
			this.UserId = userId;
			this.firstName = firstName;
			this.lastName = lastName;
			this.email = email;
			this.password=pass;
		}
		public Integer getUserId() {
			return UserId;
		}
		public void setUserId(Integer userId) {
			UserId = userId;
		}
		public String getFirstName() {
			return firstName;
		}
		public void setFirstName(String firstName) {
			this.firstName = firstName;
		}
		public String getLastName() {
			return lastName;
		}
		public void setLastName(String lastName) {
			this.lastName = lastName;
		}
		public String getEmail() {
			return email;
		}
		public void setEmail(String email) {
			this.email = email;
		}
		public String getPassword() {
			return password;
		}
		public void setPassword(String password) {
			this.password = password;
		}


		@Override
		public String toString() {
			return "User [UserId=" + UserId + ", firstName=" + firstName + ", lastName=" + lastName + ", email=" + email
					+ ", password=" + password + "]";
		}
		
}
