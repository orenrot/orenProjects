package entity;

import java.net.URLDecoder;

public class Consts {
	private Consts() {
		throw new AssertionError();
	}
	protected static final String DB_FILEPATH = getDBPath();
	public static final String CONN_STR = "jdbc:ucanaccess://" + DB_FILEPATH + ";COLUMNORDER=DISPLAY";

	/*--------------------------------------------------user queries---------------------------------------------*/
	public static final String SQL_USER_CAN_ENTER="{call UserPassReal(?,?)}";//user exsits
	public static final String SQL_USER_REQUEST_IN_TRIP="{call RequestForTripYouAreIn(?)}";
	public static final String SQL_USER_REQUEST_OUT_TRIP="{call RequestForTripsThatAreNotIn(?)}";
	public static final String SQL_INS_USER_REQUEST="{call qryINSRequest(?,?,?,?,?)}"; 
	public static final String SQL_UPD_USER_REQUSET="{call qryUpdateRequsts(?,?,?)}";
	public static final String SQL_SEL_USER_EMAIL="SELECT users.Email\r\n"
			+ "FROM users\r\n"
			+ "WHERE (((users.Email)=?));\r\n"
			+ "";
	public static final String SQL_USER_Email_BY_ID="SELECT users.Email\r\n"
			+ "FROM users\r\n"
			+ "WHERE (((users.IDUser)=?));\r\n"
			+ "";
	public static final String SQL_SEL_LAST_ID="SELECT MAX(users.IDUser) AS LastIDUser\r\n"
			+ "FROM users;\r\n"
			+ "";//LAST OR BIGGER IS THE SAME
	public static final String SQL_INS_USER="{call qryInsUser(?,?,?,?,?)}";
	public static final String SQL_SEL_TRIP_IN="{call UserTrips(?,?)}";//reviews that can be write in a trip
	public static final String SQL_SEL_VP_CULTURE="SELECT users.IDUser\r\n"
			+ "FROM users INNER JOIN VpCulture ON users.IDUser = VpCulture.IDvpCultre\r\n"
			+ "WHERE (((users.IDUser)=?));\r\n"
			+ "";
	public static final String SQL_SEL_VicePresident="SELECT users.IDUser\r\n"
			+ "FROM users INNER JOIN VicePresidnet ON users.IDUser = VicePresidnet.IDPresident\r\n"
			+ "WHERE (((users.IDUser)=?));\r\n"
			+ "";
	//need to check
	public static final String SQL_SEL_REQUEST_ForUser="SELECT DISTINCT UsersRequests.TripId\r\n"
			+ "FROM UsersRequests INNER JOIN users ON UsersRequests.Email = users.Email\r\n"
			+ "WHERE (((users.IDUser)=?) AND ((users.Email)=?) AND (UsersRequests.status=0));\r\n"
			+ "";
	public static final String SQL_SEL_USER_REQUEST_FULL_TRIP="SELECT UsersRequests.UserId, UsersRequests.TripId, UsersRequests.description, UsersRequests.[status], UsersRequests.Email\r\n"
			+ "FROM UsersRequests\r\n"
			+ "WHERE (((UsersRequests.TripId)=?) AND ((UsersRequests.[status])=0) );\r\n"
			+ "";
	/*----------------------------------------- Trip QUERIES -----------------------------------------*/
	//public static final String SQL_GET_TRIP_Reviews="{call ReviewInTrip(?)}";
	public static final String SQL_SPC_TRIP="SELECT DISTINCT Trip.*\r\n"+ "FROM Trip\r\n"+ "WHERE (((Trip.TripNumber)=?));";
	public static final String SQL_SEL_TRIP = "SELECT * FROM Trip";
	public static final String SQL_GET_TRIP_NUMBERS="SELECT Trip.TripNumber FROM Trip";
	public static final String SQL_GET_TRIP_PLACES="{call placesInTrip(?)}";
	public static final String SQL_INS_TRIP ="{ call qryINSTrip(?,?,?,?,?) }";
	public static final String SQL_DEL_Trip = "{ call qrydelTrip(?) }";
	public static final String SQL_UPD_TRIP =  "{ call qryUPDTrip(?,?,?,?) }";
	public static final String SQL_NOT_IN_TRIP="{call PlacesThatAreNotInTheTrip(?)}";
	public static final String SQL_NOT_IN_TRIP_FULL="{call FullPlacesThatAreNotInTheTrip(?)}";
	public static final String SQL_INS_PLACE_TO_TRIP="{call qryAddPlaceToTrip(?,?)}";
	public static final String SQL_INS_USER_TO_TRIP="{call  qryAddUserToTrip(?,?)}";
	public static final String SQL_DEL_USER_IN_TRIP="{call qryDeleteUserFromTrip(?,?)}";
	public static final String SQL_PLACE_REECOMEDATION_TRIP="SELECT DISTINCT PlacesThatAreNotInTheTrip.PlaceID, Places.nameOfPlace, Places.description, Places.UrlLandmark, Places.PriceLevel, Places.cityOfPlace || Places.CountryCode AS Expr1 , AVG(Reviews.score) AS Avgscore\r\n"
			+ "FROM ((trpiPlacestbl\r\n"
			+ "INNER JOIN (PlacesThatAreNotInTheTrip INNER JOIN distances ON PlacesThatAreNotInTheTrip.PlaceID = distances.placeFrom) ON trpiPlacestbl.PlaceID = distances.PlaceTo)\r\n"
			+ "INNER JOIN Reviews ON PlacesThatAreNotInTheTrip.PlaceID = Reviews.placeId)\r\n"
			+ "INNER JOIN Places ON PlacesThatAreNotInTheTrip.PlaceID = Places.PlaceID\r\n"
			+ "WHERE trpiPlacestbl.TripNumber = ? \r\n"
			+ "AND distances.distance <= ? \r\n"
			+ "AND PlacesThatAreNotInTheTrip.PlaceID NOT IN (\r\n"
			+ "    SELECT trpiPlacestbl.PlaceID\r\n"
			+ "    FROM trpiPlacestbl\r\n"
			+ "    WHERE trpiPlacestbl.TripNumber = ?\r\n"
			+ ")\r\n"
			+ "GROUP BY PlacesThatAreNotInTheTrip.PlaceID, Places.PriceLevel, Places.nameOfPlace, Places.description, Expr1, Places.UrlLandmark, distances.distance, trpiPlacestbl.TripNumber\r\n"
			+ "ORDER BY AVG(Reviews.score) DESC";
/*	public static final String SQL_PLACE_REECOMEDATION_TRIP="SELECT DISTINCT PlacesThatAreNotInTheTrip.PlaceID, Places.PriceLevel, Places.nameOfPlace, Places.UrlLandmark, Places.cityOfPlace, Places.UrlLandmark, AVG(Reviews.score) AS Avgscore\r\n"
			+ "FROM ((trpiPlacestbl\r\n"
			+ "INNER JOIN (PlacesThatAreNotInTheTrip INNER JOIN distances ON PlacesThatAreNotInTheTrip.PlaceID = distances.placeFrom) ON trpiPlacestbl.PlaceID = distances.PlaceTo)\r\n"
			+ "INNER JOIN Reviews ON PlacesThatAreNotInTheTrip.PlaceID = Reviews.placeId)\r\n"
			+ "INNER JOIN Places ON PlacesThatAreNotInTheTrip.PlaceID = Places.PlaceID\r\n"
			+ "WHERE trpiPlacestbl.TripNumber = ? \r\n"
			+ "AND distances.distance <= ? \r\n"
			+ "AND PlacesThatAreNotInTheTrip.PlaceID NOT IN (\r\n"
			+ "    SELECT trpiPlacestbl.PlaceID\r\n"
			+ "    FROM trpiPlacestbl\r\n"
			+ "    WHERE trpiPlacestbl.TripNumber = ?\r\n"
			+ ")\r\n"
			+ "GROUP BY PlacesThatAreNotInTheTrip.PlaceID, Places.PriceLevel, Places.nameOfPlace, Places.description, Places.cityOfPlace, Places.UrlLandmark, distances.distance, trpiPlacestbl.TripNumber\r\n"
			+ "ORDER BY AVG(Reviews.score) DESC"; */
	//public static final String SQL_AddReview_to_Trip="{ call qryAddReviewToTrip(?,?,?,?,?,?)}";

	public static final String SQL_PLACES_BY_PRICE="{ call PlacesNotInTripByPriceLevel(?) }";
	public static final String SQL_PLACES_BY_ACCOMEDATION="{ call PlacesFilteredByStylesAccomedationTrue(?,?) }";// WORKING
	public static final String SQL_PLACES_BY_KITCHEN="{ call PlacesByKitchenTrue(?,?) }";// 
	public static final String SQL_DEL_PLACE_IN_TRIP="{call qryDeletePlaceFromTrip(?,?)}";// one for tripId and one for placeId
	public static final String SQL_USERS_IN_TRIP="{call TravelersInTrip(?)}";
	public static final String SQL_Review_NOTIN_TRIP="{call ReviewNOTInTrip(?)}";

	public static final String SQL_PLACE_IN_TRIP="{call FullPlaceInTrip(?)}";
	public static final String SQL_USER_NOT_TRIP="{call UsersNotInTrip(?)}";
	public static final String SQL_USER_REQUEST_FOR_TRIP="SELECT UsersRequests.UserId, UsersRequests.TripId, UsersRequests.description\r\n"
			+ "FROM UsersRequests\r\n"
			+ "WHERE (((UsersRequests.TripId)=?)and (status=0) and(UsersRequests.Email='NoEmail') );";
	public static final String SQL_SEL_TRIP_BYUSER="SELECT DISTINCT Trip.*\r\n"
			+ "FROM Trip\r\n"
			+ "WHERE (((Trip.idCreator)=?));\r\n"
			+ "";
	public static final String SQL_UPD_TRIP_STATUS="{call qryUPDTripStatus(?,?)}";
	public static final String SQL_SEL_Count_Request="SELECT Count(UsersRequests.status) AS Countstatus\r\n"
			+ "FROM UsersRequests\r\n"
			+ "WHERE (((UsersRequests.status)=0))\r\n"
			+ "GROUP BY UsersRequests.TripId\r\n"
			+ "HAVING (((UsersRequests.TripId)=?));\r\n"
			+ "";
	/*-----------------------------------------Place QUERIES------------------------------*/
	public static final String SQL_Sel_place = "SELECT * FROM Places";
	public static final String SQL_INS_place = "{ call qryINSPlace(?,?,?,?,?,?,?)}";
	public static final String SQL_DEL_Place = "{ call qryDELPlace(?) }";
	public static final String SQL_UPD_Place =  "{ call qryUPDPlace(?,?,?,?,?,?,?) }";//the end is the place where to change
	public static final String SQL_SEL_CITYCODE= "SELECT Countries.CountryNumber & CityName AS Expr1\r\n"
			+ "FROM Countries INNER JOIN City ON Countries.CountryNumber = City.countryNumber;\r\n"
			+ "";
	public static final String SQL_Sel_Places_CountryName="SELECT distinct  Countries.countryName\r\n"
			+ "FROM Countries INNER JOIN (City INNER JOIN Places ON (City.countryNumber = Places.CountryCode) AND (City.CityCodes = Places.cityOfPlace)"
			+ " AND (City.CityCodes = Places.cityOfPlace)) ON (Countries.CountryNumber = Places.CountryCode) AND (Countries.CountryNumber = City.countryNumber);";
	public static final String SQL_Sel_Places_CityName="SELECT distinct  City.CityName\r\n"
			+ "FROM City INNER JOIN Places ON (City.countryNumber = Places.CountryCode) AND (City.CityCodes = Places.cityOfPlace) AND (City.CityCodes = Places.cityOfPlace);";
	public static final String SQL_Sel_Place_ByCityName="{call PlacesByCityName(?)}";
	public static final String SQL_Sel_Place_ByCountryName="{call PlacesByCountryName(?)}";
	public static final String SQL_SEL_Distances="SELECT distances.*\r\n"
			+ "FROM distances;";
	public static final String SQL_Ins_DistancePlaces="{call qryInsertDistance(?,?,?)}";
	public static final String SQL_DEL_Distance="{call qryDeleteDistance(?,?)}";
	public static final String SQL_UPD_Distance="{call qryUPDistance(?,?,?)}";
	/*-----------------------------------------Hotel QUERIES------------------------------*/

	public static final String SQL_SEL_Hotels = "SELECT Places.*, Hotels.starsRating\r\n"
			+ "FROM Places INNER JOIN Hotels ON Places.PlaceID = Hotels.HotelID;\r\n"
			+ "";
	public static final String SQL_INS_Hotels = "{ call qryINSHotel(?,?) }";
	public static final String SQL_DEL_Hotels = "{ call qryDELHotel(?) }";
	public static final String SQL_UPD_Hotels =  "{ call qryUPDHotel(?,?) }";
	public static final String SQL_INS_HOTEL_Style="{call qryInsetHotelStyle(?,?)}";

	/*-----------------------------------------Resturant QUERIES------------------------------*/

	public static final String SQL_SEL_Resturant = "SELECT Places.PlaceID, Places.nameOfPlace, Places.description, Places.UrlLandmark, Places.PriceLevel, [CityOfPlace] & [CountryCode] AS Expr1, Resturant.StarRating, Resturant.kitchenStyles\r\n"
			+ "FROM Places INNER JOIN Resturant ON Places.PlaceID = Resturant.ResturantId;\r\n"
			+ ""+"";
	public static final String SQL_INS_Resturant= "{ call qryINSResturant(?,?,?) }";
	public static final String SQL_DEL_Resturant = "{ call qryDELResturant(?) }";
	public static final String SQL_UPD_ResturantStyle =  "{ call qryUPDResturantStyle(?,?) }";
	public static final String SQL_SEL_KITCHEN="SELECT KitchenStylesEnum.kitchenStyles\r\n"
			+ "FROM KitchenStylesEnum;";
	/*-----------------------------------------Reviews QUERIES------------------------------*/

	public static final String SQL_SEL_Reviews = "SELECT * FROM Reviews";
//	public static final String SQL_SEL_Revives_With_Intital="SELECT Reviews.ReviewID, Reviews.score, Reviews.comment, Reviews.placeId, Left(UserId, 1) AS UserId, Reviews.TripNumber\r\n"
//			+ "FROM Reviews;";
	public static final String SQL_INS_Reviews = "{ call qryINSReviews (?,?,?,?,?,?,?) }";
	public static final String SQL_DEL_Reviews  = "{ call qryDELReviews (?) }";
	public static final String SQL_DEL_Reviews_BY_TRIP_ID  = "{ call qryDeleteReviewByTripID (?) }";
	//public static final String SQL_UPD_Reviews  =  "{ call qryUPDReviewse (?,?,?,?,?,?) }";
	public static final String SQL_LAST_ReviewsID= "SELECT Max(Reviews.ReviewID) AS MaxReviewID\r\n"
			+ "FROM Reviews;\r\n"
			+ "";
	public static final String SQL_SEL_USER_Reivews="SELECT Reviews.ReviewID, Reviews.score, Reviews.comment, Reviews.placeId,Reviews.UserId ,Reviews.TripNumber, Reviews.timeWrite\r\n"
			+ "FROM Reviews\r\n"
			+ "WHERE (((Reviews.UserId)=?));";
	public static final String SQL_UPD_ReviewSpecific="{ call qryUPDReview(?,?,?,?)}";
	/*-------------------------------------------Country queries-------------------------------------------------------*/
/*	public static final String SQL_SEL_CountryNumber="SELECT Countries.countryName\r\n" + "FROM Countries;";
	
	
	/*-------------------------------------------city queries-------------------------------------------------------*/
	/*public static final String SQL_SEL_CityName="SELECT City.CityName\r\n"
			+ "FROM City;\r\n"
			+ "";
	/*--------------------------------------------------for xml/json----------------------------------------------------------------*/
    public enum Manipulation {
    	UPDATE, INSERT, DELETE;
    }
	
	//	File filePath = new File("perfectTrip 21.2.24.accdb");
	//	String path2=filePath.getAbsolutePath();
	//	String decoded2 = URLDecoder.decode(path2, "UTF-8");
	//	System.out.println("decoded2="+decoded2);
	//	System.out.println("path2="+path2);
	//String pathWithForwardSlashes ="/"+ path2.replace("\\", "/");
	//System.out.println("correct="+pathWithForwardSlashes);
	//return pathWithForwardSlashes;
    /**
	 * find the correct path of the DB file
     * @return the path of the DB file (from eclipse or with runnable file)
	 */
	private static String getDBPath() {
		try {
			String path = Consts.class.getProtectionDomain().getCodeSource().getLocation().getPath();
			String decoded = URLDecoder.decode(path, "UTF-8");
			if (decoded.contains(".jar")) {
				decoded = decoded.substring(0, decoded.lastIndexOf('/'));
				return decoded + "/database/perfectTrip 21.2.24 backup4.accdb";
			} else {
				decoded = decoded.substring(0, decoded.lastIndexOf("bin/"));
				System.out.println(decoded);
				return decoded + "src/entity/perfectTrip 21.2.24 backup4.accdb";
			}
		} catch (Exception e) {
			e.printStackTrace();
			return null;
		}
	}
}
