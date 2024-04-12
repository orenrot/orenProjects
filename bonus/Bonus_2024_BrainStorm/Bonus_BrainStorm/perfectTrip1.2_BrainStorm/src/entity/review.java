package entity;

import java.util.Date;

public class review {
	protected Integer reviewID;
	protected Integer score;
	protected String comment;
	protected Integer placeId;
	protected Integer userId;
	protected Integer tripNumber;
	protected Date timeWrite;
	
	public review(Integer reviewID, Integer score, String comment, Integer placeId, Integer userId, Integer tripNumber,
			Date timeWrite) {
		super();
		this.reviewID = reviewID;
		this.score = score;
		this.comment = comment;
		this.placeId = placeId;
		this.userId = userId;
		this.tripNumber = tripNumber;
		this.timeWrite = timeWrite;
	}
	public review(Integer reviewID, Integer score, String comment, Integer placeId, Integer userId,
			Integer tripNumber) {
		super();
		this.reviewID = reviewID;
		this.score = score;
		this.comment = comment;
		this.placeId = placeId;
		this.userId = userId;
		this.tripNumber = tripNumber;
	}
	public review(Integer reviewID, Integer score,String comment, Integer placeId, Integer userId) {
		super();
		this.reviewID = reviewID;
		this.score = score;
		this.comment=comment;
		this.placeId = placeId;
		this.userId = userId;
	}
	public Integer getReviewID() {
		return reviewID;
	}
	public String getComment() {
		return comment;
	}
	public void setComment(String comment) {
		this.comment = comment;
	}
	public void setReviewID(Integer reviewID) {
		this.reviewID = reviewID;
	}
	public Integer getScore() {
		return score;
	}
	public void setScore(Integer score) {
		this.score = score;
	}
	public Integer getPlaceId() {
		return placeId;
	}
	public void setPlaceId(Integer placeId) {
		this.placeId = placeId;
	}
	public Integer getUserId() {
		return userId;
	}
	public void setUserId(Integer userId) {
		this.userId = userId;
	}
	public Integer getTripNumber() {
		return tripNumber;
	}
	public Date getTimeWrite() {
		return timeWrite;
	}

	
}
