package entity;

import java.sql.Date;
import java.util.ArrayList;
import java.util.Objects;



public class Trip {
	
		protected Integer tripId;
		protected Date startDate;
		protected Date endDate;
		protected Integer tripCreator;
		protected Integer status;
		
		
		public Trip(Integer tripId, Date startDate, Date endDate, Integer tripCreator, Integer status) {
			super();
			this.tripId = tripId;
			this.startDate = startDate;
			this.endDate = endDate;
			this.tripCreator = tripCreator;
			this.status = status;
		}
		public Trip(Integer tripId, Date startDate,
				Date endDate, Integer tripCreator) {
			super();
			this.tripId = tripId;
			this.startDate = startDate;
			this.endDate = endDate;
			this.tripCreator = tripCreator;
		}
		public Trip() {
			// TODO Auto-generated constructor stub
		}
		/*public boolean AddPlace(Integer newUserToTrip)
		{
			if(additionalTravelers.add(newUserToTrip))
				return true;
			else
				return false;
		}*/
		public Integer getTripId() {
			return tripId;
		}
		public void setTripId(Integer tripId) {
			this.tripId = tripId;
		}
		public Date getStartDate() {
			return startDate;
		}
		public void setStartDate(Date startDate) {
			this.startDate = startDate;
		}
		public Date getEndDate() {
			return endDate;
		}
		public void setEndDate(Date endDate) {
			this.endDate = endDate;
		}
		public Integer getTripCreator() {
			return tripCreator;
		}
		public void setTripCreator(Integer tripCreator) {
			this.tripCreator = tripCreator;
		}	
		
		public Integer getStatus() {
			return status;
		}
		public void setStatus(Integer status) {
			this.status = status;
		}
		@Override
		public String toString() {
			return "Trip [tripId=" + tripId + ", startDate=" + startDate + ", endDate=" + endDate + ", tripCreator="
					+ tripCreator + ", status=" + status + "]";
		}
		@Override
		public int hashCode() {
			return Objects.hash(endDate, startDate, status, tripCreator, tripId);
		}
		@Override
		public boolean equals(Object obj) {
			if (this == obj)
				return true;
			if (obj == null)
				return false;
			if (getClass() != obj.getClass())
				return false;
			Trip other = (Trip) obj;
			return Objects.equals(endDate, other.endDate) && Objects.equals(startDate, other.startDate)
					&& Objects.equals(status, other.status) && Objects.equals(tripCreator, other.tripCreator)
					&& Objects.equals(tripId, other.tripId);
		}

}
