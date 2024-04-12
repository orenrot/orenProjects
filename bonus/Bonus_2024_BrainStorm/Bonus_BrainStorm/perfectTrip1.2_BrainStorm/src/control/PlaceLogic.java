package control;

import java.io.File;
import java.io.IOException;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.time.LocalDateTime;
import java.util.ArrayList;

import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.OutputKeys;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;

import org.w3c.dom.Attr;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

import entity.Consts;
import entity.Consts.Manipulation;
import entity.DistanceTable;
import entity.Place;

public class PlaceLogic {
	private static PlaceLogic _instancePlace;

	public PlaceLogic() {
	}

	public static PlaceLogic getInstance() {
		if (_instancePlace == null)
			_instancePlace = new PlaceLogic();
		return _instancePlace;
	}
	/*-----------------------------------------get functions-----------------------------------------------------------------------*/
	/*-----------------------------------------get place-----------------------------------------------------------------------*/
	public ArrayList<Place> getPlace() {
		ArrayList<Place> results = new ArrayList<Place>();
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt = conn.prepareStatement(Consts.SQL_Sel_place);
					ResultSet rs = stmt.executeQuery()) {
				while (rs.next()) {
					int i = 1;
					results.add(new Place(rs.getInt(i++), rs.getString(i++), rs.getString(i++), rs.getInt(i++),
							rs.getString(i++), (rs.getString(i++)),(rs.getInt(i++))));// need to check
				}
			} catch (SQLException e) {
				e.printStackTrace();
			}
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
		return results;
	}
	/*-----------------------------------------get city code-----------------------------------------------------------------------*/
	public  ArrayList<String> getCityCodes() 
	{  //need to check if i use it
			ArrayList<String> results = new ArrayList<String>();
	    
	    try {
	        // Load the UCanAccess JDBC driver
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        // Establish connection, execute query, and retrieve results
	        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
	             PreparedStatement stmt = conn.prepareStatement(Consts.SQL_SEL_CITYCODE);
	             ResultSet rs = stmt.executeQuery()) {
	            
	            // Iterate over the result set and create Place objects
	            while (rs.next()) {
	                // Retrieve data from the result set and create a Place object
	                int i = 1;
	                results.add( rs.getString(i++));
	            }
	        }
	    } catch (ClassNotFoundException e) {
	        // Handle ClassNotFoundException (driver not found)
	        e.printStackTrace();
	        System.err.println("UCanAccess JDBC driver not found");
	    } catch (SQLException e) {
	        // Handle SQLException (database access error)
	        e.printStackTrace();
	        System.err.println("Error accessing database: " + e.getMessage());
	    } catch (Exception e) {
	        // Handle other exceptions
	        e.printStackTrace();
	        System.err.println("Unexpected error: " + e.getMessage());
	    }
	    return results;
	}
	/*-----------------------------------------get all places country name-----------------------------------------------------------------------*/
	public  ArrayList<String> getCountryName()
	{
	ArrayList<String> results = new ArrayList<String>();
	    
	    try {
	        // Load the UCanAccess JDBC driver
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        // Establish connection, execute query, and retrieve results
	        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
	             PreparedStatement stmt = conn.prepareStatement(Consts.SQL_Sel_Places_CountryName);
	             ResultSet rs = stmt.executeQuery()) {
	            
	            // Iterate over the result set and create Place objects
	            while (rs.next()) {
	                // Retrieve data from the result set and create a Place object
	                int i = 1;
	                results.add( rs.getString(i++));
	            }
	        }
	    } catch (ClassNotFoundException e) {
	        // Handle ClassNotFoundException (driver not found)
	        e.printStackTrace();
	        System.err.println("UCanAccess JDBC driver not found");
	    } catch (SQLException e) {
	        // Handle SQLException (database access error)
	        e.printStackTrace();
	        System.err.println("Error accessing database: " + e.getMessage());
	    } catch (Exception e) {
	        // Handle other exceptions
	        e.printStackTrace();
	        System.err.println("Unexpected error: " + e.getMessage());
	    }
	    return results;
	}
	/*-----------------------------------------get  places by specific country name-----------------------------------------------------------------------*/
	public ArrayList<Place> getPlaceByCountryName(String countryName)
	{
		ArrayList<Place> results = new ArrayList<Place>();
			    
			    try {
			        // Load the UCanAccess JDBC driver
			        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			        // Establish connection, execute query, and retrieve results
			        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
			        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_Sel_Place_ByCountryName);) {
						stmt1.setString(1, countryName);
				           ResultSet rs =stmt1.executeQuery();
				        	   
					            while (rs.next()) {
					                // Retrieve data from the result set and create a Place object
					                int i = 1;
					                Place place = new Place(
					                        rs.getInt(i++),
					                        rs.getString(i++),
					                        rs.getString(i++),
					                        rs.getInt(i++),
					                        rs.getString(i++),
					                        rs.getString(i++));
					                // Add the Place object to the results list
					                results.add(place);
					            }
			        }
			    } catch (ClassNotFoundException | SQLException e) {
					e.printStackTrace();
				}
			    return results;
	}
	/*-----------------------------------------get all places city name-----------------------------------------------------------------------*/
	public  ArrayList<String> getCityName()
	{
		ArrayList<String> results = new ArrayList<String>();
		    
		    try {
		        // Load the UCanAccess JDBC driver
		        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
		        // Establish connection, execute query, and retrieve results
		        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
		             PreparedStatement stmt = conn.prepareStatement(Consts.SQL_Sel_Places_CityName);
		             ResultSet rs = stmt.executeQuery()) {
		            
		            // Iterate over the result set and create Place objects
		            while (rs.next()) {
		                // Retrieve data from the result set and create a Place object
		                int i = 1;
		                results.add( rs.getString(i++));
		            }
		        }
		    } catch (ClassNotFoundException e) {
		        // Handle ClassNotFoundException (driver not found)
		        e.printStackTrace();
		        System.err.println("UCanAccess JDBC driver not found");
		    } catch (SQLException e) {
		        // Handle SQLException (database access error)
		        e.printStackTrace();
		        System.err.println("Error accessing database: " + e.getMessage());
		    } catch (Exception e) {
		        // Handle other exceptions
		        e.printStackTrace();
		        System.err.println("Unexpected error: " + e.getMessage());
		    }
		    return results;
	}
	/*-----------------------------------------get  places by specific city name-----------------------------------------------------------------------*/
	public ArrayList<Place> getPlaceByCityName(String cityName)
	{
		ArrayList<Place> results = new ArrayList<Place>();
			    
			    try {
			        // Load the UCanAccess JDBC driver
			        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			        // Establish connection, execute query, and retrieve results
			        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
			        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_Sel_Place_ByCityName);) {
						stmt1.setString(1, cityName);
				           ResultSet rs =stmt1.executeQuery();
				        	   
					            while (rs.next()) {
					                // Retrieve data from the result set and create a Place object
					                int i = 1;
					                Place place = new Place(
					                        rs.getInt(i++),
					                        rs.getString(i++),
					                        rs.getString(i++),
					                        rs.getInt(i++),
					                        rs.getString(i++),
					                        rs.getString(i++));
					                // Add the Place object to the results list
					                results.add(place);
					            }
			        }
			    } catch (ClassNotFoundException | SQLException e) {
					e.printStackTrace();
				}
			    return results;
	}
	/*----------------------------------------------add functions----------------------------------------------------------*/
	/*----------------------------------------------add distance-----------------------------*/
	public boolean InsertDistance(Integer placeFrom,Integer placeTo,Integer distance)
	{
		try{
	    	 Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        try (Connection conn = DriverManager.getConnection(connStr);
	             CallableStatement stmt = conn.prepareCall(Consts.SQL_Ins_DistancePlaces)) { 
	            stmt.setInt(1, placeFrom);
	            stmt.setInt(2, placeTo);
	            stmt.setInt(3, distance);
	            stmt.executeUpdate();
	            return true;
	        } catch (SQLException e) {
	            e.printStackTrace();
	            return false;
	        }
	    } catch (ClassNotFoundException e) {
	        e.printStackTrace();
	    }
		return false;		
	}
	
	/*----------------------------------------------xml functions----------------------------------------------------------*/
	/***
	 * export places to xml
	 * @throws ClassNotFoundException 
	 */
    public void exportPlacesToXML2() 
    {
    	
		try {
			Document doc;
			doc = DocumentBuilderFactory.newInstance()
			        .newDocumentBuilder().newDocument();
				Element rootElement = doc.createElement("Places_info");
		        rootElement.setAttribute("exportDate", LocalDateTime.now().toString());
		        doc.appendChild(rootElement);
		        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
				try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
				        PreparedStatement stmt = conn.prepareStatement( Consts.SQL_Sel_place);
				        ResultSet rs = stmt.executeQuery()) {
				    
				    // create document object.
				    
				    
				    while (rs.next()) {     // run on all customer records..
				        // create customer element.
				        Element customer = doc.createElement("Place");
				        
				        // assign key to customer.
				        Attr attr = doc.createAttribute("PlaceID");
				        attr.setValue(rs.getString(1));
				        customer.setAttributeNode(attr);
				        
				        // push elements to customer.
				        for (int i = 2; i <= rs.getMetaData().getColumnCount(); i++) {
				            Element element = doc.createElement(
				                    rs.getMetaData().getColumnName(i)); // push element to doc.
				            rs.getObject(i); // for wasNull() check..
				            element.appendChild(doc.createTextNode(
				                    rs.wasNull() ? "" : rs.getString(i)));  // set element value.
				            customer.appendChild(element);  // push element to customer.
				        }
				        
				        // push customer to document's root element.
				        rootElement.appendChild(customer);
				    }
				    // write the content into xml file
				    
				    DOMSource source = new DOMSource(doc);
				    File file = new File("xml/places.xml");
				    file.getParentFile().mkdir(); // create xml folder if doesn't exist.
				    StreamResult result = new StreamResult(file);
				    TransformerFactory factory = TransformerFactory.newInstance();
				    
				    // IF CAUSES ISSUES, COMMENT THIS LINE.
				    factory.setAttribute("indent-number", 2);
				    //
				    
				    Transformer transformer = factory.newTransformer();
				    
				    // IF CAUSES ISSUES, COMMENT THESE 2 LINES.
				    transformer.setOutputProperty(OutputKeys.INDENT, "yes");
				    transformer.setOutputProperty("{http://xml.apache.org/xslt}indent-amount", "2");
				    //
				    
				    transformer.transform(source, result);
				    
				    System.out.println("places data exported successfully!");
			
				
				try (Connection conn2 = DriverManager.getConnection(Consts.CONN_STR);
				        PreparedStatement stmt2 = conn2.prepareStatement( Consts.SQL_SEL_Distances);
				        ResultSet rs2 = stmt2.executeQuery()) {
					Document doc2;
					doc2 = DocumentBuilderFactory.newInstance().newDocumentBuilder().newDocument();
					 rootElement = doc2.createElement("DistanceData_info");
				     rootElement.setAttribute("exportDate", LocalDateTime.now().toString());
				      doc2.appendChild(rootElement);
            
	            while (rs2.next()) {     // run on all customer records..
	                // create customer element.
	                Element distnace = doc2.createElement("Distance");
	                
	                // assign key to customer.
	                Attr attr = doc2.createAttribute("PlaceFrom");
	                attr.setValue(rs2.getString(1));
	                distnace.setAttributeNode(attr);
	                System.out.println("attr="+attr);
	                Attr attr2 = doc2.createAttribute("PlaceTo");
	                attr2.setValue(rs2.getString(2));
	                distnace.setAttributeNode(attr2);
	                System.out.println("attr="+attr2);
	              //  Attr attr3 = doc2.createAttribute("PlaceTo");
	              //  attr3.setValue(rs2.getString(3));
	              //  distnace.setAttributeNode(attr3);
	                // push elements to customer.
	                System.out.println( rs2.getMetaData().getColumnCount());
	                for (int i = 3; i <= rs2.getMetaData().getColumnCount(); i++) {
	                	   Element element = doc2.createElement(
	                			   rs2.getMetaData().getColumnName(i)); // push element to doc.
	                	   rs2.getObject(i); // for wasNull() check..
	                	   System.out.println( rs2.getObject(i));
				            element.appendChild(doc2.createTextNode(
				                    rs2.wasNull() ? "" : rs2.getString(i)));  // set element value.
				            System.out.println(element);
				            distnace.appendChild(element);  // push element to customer.
				        }
	                System.out.println(distnace);
	                	//distnace.appendChild(attr);
				        // push customer to document's root element.
				        rootElement.appendChild(distnace);
				     //   System.out.println(rootElement);
				    }
				    // write the content into xml file
				    
				    DOMSource source2 = new DOMSource(doc2);
				    File file2 = new File("xml/distance.xml");
				    file2.getParentFile().mkdir(); // create xml folder if doesn't exist.
				    StreamResult result2 = new StreamResult(file2);
				    TransformerFactory factory2 = TransformerFactory.newInstance();
				    
				    // IF CAUSES ISSUES, COMMENT THIS LINE.
				    factory2.setAttribute("indent-number", 2);
				    //
				    
				    Transformer transformer2 = factory2.newTransformer();
				    
				    // IF CAUSES ISSUES, COMMENT THESE 2 LINES.
				    transformer.setOutputProperty(OutputKeys.INDENT, "yes");
				    transformer.setOutputProperty("{http://xml.apache.org/xslt}indent-amount", "2");
				    //
				    
				    transformer.transform(source2, result2);
				    
			    
			    System.out.println("distance data exported successfully!");
	            
        
        // push root element into document object.
      
		}
				} catch (SQLException | NullPointerException | TransformerException e) {
				    e.printStackTrace();
				}
				
		}
		catch (ParserConfigurationException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		} catch (ClassNotFoundException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}
    }
    public void exportPlacesToXML3() 
    {
    	
		try {
			Document doc;
			doc = DocumentBuilderFactory.newInstance()
			        .newDocumentBuilder().newDocument();
				Element rootElement = doc.createElement("Places_info");
		        rootElement.setAttribute("exportDate", LocalDateTime.now().toString());
		        doc.appendChild(rootElement);
		        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
				try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
				        PreparedStatement stmt = conn.prepareStatement( Consts.SQL_Sel_place);
				        ResultSet rs = stmt.executeQuery()) {
				    
				    // create document object.
				    
				    
				    while (rs.next()) {     // run on all customer records..
				        // create customer element.
				        Element customer = doc.createElement("Place");
				        
				        // assign key to customer.
				        Attr attr = doc.createAttribute("PlaceID");
				        attr.setValue(rs.getString(1));
				        customer.setAttributeNode(attr);
				        
				        // push elements to customer.
				        for (int i = 2; i <= rs.getMetaData().getColumnCount(); i++) {
				            Element element = doc.createElement(
				                    rs.getMetaData().getColumnName(i)); // push element to doc.
				            rs.getObject(i); // for wasNull() check..
				            element.appendChild(doc.createTextNode(
				                    rs.wasNull() ? "" : rs.getString(i)));  // set element value.
				            customer.appendChild(element);  // push element to customer.
				        }
				        
				        // push customer to document's root element.
				        rootElement.appendChild(customer);
				    }
				    // write the content into xml file
				    
				    DOMSource source = new DOMSource(doc);
				    //File file = new File("xml/places.xml");
				   // file.getParentFile().mkdir(); // create xml folder if doesn't exist.
				  //  StreamResult result = new StreamResult(file);
				    TransformerFactory factory = TransformerFactory.newInstance();
				    
				    // IF CAUSES ISSUES, COMMENT THIS LINE.
				    factory.setAttribute("indent-number", 2);
				    //
				    
				   Transformer transformer = factory.newTransformer();
				    
				    // IF CAUSES ISSUES, COMMENT THESE 2 LINES.
				//    transformer.setOutputProperty(OutputKeys.INDENT, "yes");
				//    transformer.setOutputProperty("{http://xml.apache.org/xslt}indent-amount", "2");
				    //
				    
				 //   transformer.transform(source, result);
				    
				//    System.out.println("places data exported successfully!");
			
				
				try (Connection conn2 = DriverManager.getConnection(Consts.CONN_STR);
				        PreparedStatement stmt2 = conn2.prepareStatement( Consts.SQL_SEL_Distances);
				        ResultSet rs2 = stmt2.executeQuery()) {
					/*Document doc2;
					doc2 = DocumentBuilderFactory.newInstance().newDocumentBuilder().newDocument();
					 rootElement = doc2.createElement("DistanceData_info");
				     rootElement.setAttribute("exportDate", LocalDateTime.now().toString());
				      doc2.appendChild(rootElement);*/
            
	            while (rs2.next()) {     // run on all customer records..
	                // create customer element.
	                Element distnace = doc.createElement("Distance");
	                
	                // assign key to customer.
	                Attr attr = doc.createAttribute("PlaceFrom");
	                attr.setValue(rs2.getString(1));
	                distnace.setAttributeNode(attr);
	  
	                Attr attr2 = doc.createAttribute("PlaceTo");
	                attr2.setValue(rs2.getString(2));
	                distnace.setAttributeNode(attr2);
	                for (int i = 3; i <= rs2.getMetaData().getColumnCount(); i++) {
	                	   Element element = doc.createElement(
	                			   rs2.getMetaData().getColumnName(i)); // push element to doc.
	                	   rs2.getObject(i); // for wasNull() check..
	 
				            element.appendChild(doc.createTextNode(
				                    rs2.wasNull() ? "" : rs2.getString(i)));  // set element value.
	
				            distnace.appendChild(element);  // push element to customer.
				        }

				        // push customer to document's root element.
				        rootElement.appendChild(distnace);
				    }
				    // write the content into xml file
				    
				    DOMSource source2 = new DOMSource(doc);
				    File file2 = new File("xml/distance.xml");
				    file2.getParentFile().mkdir(); // create xml folder if doesn't exist.
				    StreamResult result2 = new StreamResult(file2);
				    TransformerFactory factory2 = TransformerFactory.newInstance();
				    
				    // IF CAUSES ISSUES, COMMENT THIS LINE.
				    factory2.setAttribute("indent-number", 2);
				    //
				    
				    Transformer transformer2 = factory2.newTransformer();
				    
				    // IF CAUSES ISSUES, COMMENT THESE 2 LINES.
				    transformer.setOutputProperty(OutputKeys.INDENT, "yes");
				    transformer.setOutputProperty("{http://xml.apache.org/xslt}indent-amount", "2");
				    //
				    
				    transformer.transform(source2, result2);
				    
			    
			    System.out.println("distance data exported successfully!");
	            
        
        // push root element into document object.
      
		}
				} catch (SQLException | NullPointerException | TransformerException e) {
				    e.printStackTrace();
				}
				
		}
		catch (ParserConfigurationException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		} catch (ClassNotFoundException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}
    }
    /*    public void exportPlacesToXML() {
            try {
                Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
                try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
                        PreparedStatement stmt = conn.prepareStatement( Consts.SQL_Sel_place);
                        ResultSet rs = stmt.executeQuery()) {
                    
                    // create document object.
                    Document doc = DocumentBuilderFactory.newInstance()
                            .newDocumentBuilder().newDocument();
                    
                    // push root element into document object.
                    Element rootElement = doc.createElement("Places_info");
                    rootElement.setAttribute("exportDate", LocalDateTime.now().toString());
                    doc.appendChild(rootElement);
                    
                    while (rs.next()) {     // run on all customer records..
                        // create customer element.
                        Element customer = doc.createElement("Place");
                        
                        // assign key to customer.
                        Attr attr = doc.createAttribute("PlaceID");
                        attr.setValue(rs.getString(1));
                        customer.setAttributeNode(attr);
                        
                        // push elements to customer.
                        for (int i = 2; i <= rs.getMetaData().getColumnCount(); i++) {
                            Element element = doc.createElement(
                                    rs.getMetaData().getColumnName(i)); // push element to doc.
                            rs.getObject(i); // for wasNull() check..
                            element.appendChild(doc.createTextNode(
                                    rs.wasNull() ? "" : rs.getString(i)));  // set element value.
                            customer.appendChild(element);  // push element to customer.
                        }
                        
                        // push customer to document's root element.
                        rootElement.appendChild(customer);
                    }
                     stmt = conn.prepareStatement( Consts.SQL_SEL_Distances);
                     rs = stmt.executeQuery()) {
                
                rootElement = doc.createElement("DistanceData_info");
                rootElement.setAttribute("exportDate", LocalDateTime.now().toString());
                doc.appendChild(rootElement);
                
                while (rs.next()) {     // run on all customer records..
                    // create customer element.
                    Element distnace = doc.createElement("Distance");
                    
                    // assign key to customer.
                    Attr attr = doc.createAttribute("PlaceFrom");
                    attr.setValue(rs.getString(1));
                    distnace.setAttributeNode(attr);
                  
                    Attr attr2 = doc.createAttribute("PlaceTo");
                    attr.setValue(rs.getString(2));
                    distnace.setAttributeNode(attr);
                    // push elements to customer.
                    for (int i = 3; i <= rs.getMetaData().getColumnCount(); i++) {
                        Element element = doc.createElement(
                                rs.getMetaData().getColumnName(i)); // push element to doc.
                        rs.getObject(i); // for wasNull() check..
                        element.appendChild(doc.createTextNode(
                                rs.wasNull() ? "" : rs.getString(i)));  // set element value.
                        distnace.appendChild(element);  // push element to customer.
                    }
                    
                    // push customer to document's root element.
                    rootElement.appendChild(distnace);
                }
                    // write the content into xml file
                    
                    DOMSource source = new DOMSource(doc);
                    File file = new File("xml/places.xml");
                    file.getParentFile().mkdir(); // create xml folder if doesn't exist.
                    StreamResult result = new StreamResult(file);
                    TransformerFactory factory = TransformerFactory.newInstance();
                    
                    // IF CAUSES ISSUES, COMMENT THIS LINE.
                    factory.setAttribute("indent-number", 2);
                    //
                    
                    Transformer transformer = factory.newTransformer();
                    
                    // IF CAUSES ISSUES, COMMENT THESE 2 LINES.
                    transformer.setOutputProperty(OutputKeys.INDENT, "yes");
                    transformer.setOutputProperty("{http://xml.apache.org/xslt}indent-amount", "2");
                    //
                    
                    transformer.transform(source, result);
                    
                    System.out.println("places data exported successfully!");
                } catch (SQLException | NullPointerException | ParserConfigurationException
                        | TransformerException e) {
                    e.printStackTrace();
                }
            } catch (ClassNotFoundException e) {
                e.printStackTrace();
            }
        }*/
    /**
     * imports places from xml to db.
     * @param path xml filepath.
     */
  /*  public void importPlacesFromXML(String path,String path2) {
    	try {
			Document doc = DocumentBuilderFactory.newInstance()
								.newDocumentBuilder().parse(new File(path));
			doc.getDocumentElement().normalize();
			NodeList nl = doc.getElementsByTagName("Place");
			
			int errors = 0;
			for (int i = 0; i < nl.getLength(); i++) {
				if (nl.item(i).getNodeType() == Node.ELEMENT_NODE) {
					Element el = (Element) nl.item(i);
					Place c = new Place(Integer.parseInt(el.getAttribute("PlaceID")), 
							el.getElementsByTagName("nameOfPlace").item(0).getTextContent(),
							el.getElementsByTagName("description").item(0).getTextContent(),
						Integer.parseInt(el.getElementsByTagName("UrlLandmark").item(0).getTextContent().toString()),
							el.getElementsByTagName("PriceLevel").item(0).getTextContent(),
							el.getElementsByTagName("cityOfPlace").item(0).getTextContent(),
						 Integer.parseInt(el.getElementsByTagName("CountryCode").item(0).getTextContent()));
					//System.out.println(el.getElementsByTagName("CountryCode").item(0).getTextContent());
				//	System.out.println(c);
					if (!manipulatePlace(c, entity.Consts.Manipulation.INSERT) && 
							!manipulatePlace(c, entity.Consts.Manipulation.UPDATE))
						errors++;
				}
			}
			Document doc2 = DocumentBuilderFactory.newInstance()
					.newDocumentBuilder().parse(new File(path2));
			doc2.getDocumentElement().normalize();
			NodeList nl2 = doc.getElementsByTagName("Distance");

			ArrayList<Place> allPlaces=PlaceLogic.getInstance().getPlace();//get all places
			
			Integer distnace=0;
			Integer placeFrom=0;
			Integer   placeTo=0;
			int i=0;
			while(i<allPlaces.size())
			{
				for(Place p:allPlaces)
				{
				///	System.out.println(p);
					if(!p.equals(allPlaces.get(i)))
					{
					//	System.out.println("enterd");
						placeFrom=p.getPlaceId();
						placeTo=allPlaces.get(i).getPlaceId();
						distnace=Math.abs((p.getUrlLandmark()-allPlaces.get(i).getUrlLandmark()));//the distance
						if (!manipulateDistance(placeFrom,placeTo,distnace, entity.Consts.Manipulation.INSERT) && 
								!manipulateDistance(placeFrom,placeTo,distnace, entity.Consts.Manipulation.UPDATE))
							errors++;
						//System.out.println("enterd");
					}
				}
				i++;
			}
			System.out.println((errors == 0) ? "places data imported successfully!" : 
				String.format("places data imported with %d errors!", errors));
			
		} catch (SAXException | IOException | ParserConfigurationException e) {
			e.printStackTrace();
		}
    }*/
    /*-------------------------------------------------------import all to one and calculate disntace---------------------------------------------------------------------*/
    public void importPlacesFromXML2(String path) {
    	try {
			Document doc = DocumentBuilderFactory.newInstance()
								.newDocumentBuilder().parse(new File(path));
			doc.getDocumentElement().normalize();
			NodeList nl = doc.getElementsByTagName("Place");
			
			int errors = 0;
			for (int i = 0; i < nl.getLength(); i++) {
				if (nl.item(i).getNodeType() == Node.ELEMENT_NODE) {
					Element el = (Element) nl.item(i);
					Place c = new Place(Integer.parseInt(el.getAttribute("PlaceID")), 
							el.getElementsByTagName("nameOfPlace").item(0).getTextContent(),
							el.getElementsByTagName("description").item(0).getTextContent(),
						Integer.parseInt(el.getElementsByTagName("UrlLandmark").item(0).getTextContent().toString()),
							el.getElementsByTagName("PriceLevel").item(0).getTextContent(),
							el.getElementsByTagName("cityOfPlace").item(0).getTextContent(),
						 Integer.parseInt(el.getElementsByTagName("CountryCode").item(0).getTextContent()));
					//System.out.println(el.getElementsByTagName("CountryCode").item(0).getTextContent());
				//	System.out.println(c);
					if (!manipulatePlace(c, entity.Consts.Manipulation.INSERT) && 
							!manipulatePlace(c, entity.Consts.Manipulation.UPDATE))
						errors++;
				}
			}
			 nl = doc.getElementsByTagName("Hotel");
			
			 errors = 0;
			for (int i = 0; i < nl.getLength(); i++) {
				if (nl.item(i).getNodeType() == Node.ELEMENT_NODE) {
					Element el = (Element) nl.item(i);
					Place c = new Place(Integer.parseInt(el.getAttribute("PlaceID")), 
							el.getElementsByTagName("nameOfPlace").item(0).getTextContent(),
							el.getElementsByTagName("description").item(0).getTextContent(),
						Integer.parseInt(el.getElementsByTagName("UrlLandmark").item(0).getTextContent().toString()),
							el.getElementsByTagName("PriceLevel").item(0).getTextContent(),
							el.getElementsByTagName("cityOfPlace").item(0).getTextContent(),
						 Integer.parseInt(el.getElementsByTagName("CountryCode").item(0).getTextContent()));
					//System.out.println(el.getElementsByTagName("CountryCode").item(0).getTextContent());
				//	System.out.println(c);
					if (!manipulatePlace(c, entity.Consts.Manipulation.INSERT) && 
							!manipulatePlace(c, entity.Consts.Manipulation.UPDATE))
						errors++;
					Integer hotelId=Integer.parseInt(el.getAttribute("PlaceID"));
					Integer hotelStar=Integer.parseInt(el.getElementsByTagName("starsRating").item(0).getTextContent());
					//System.out.println(hotelId+" s="+hotelStar);
					
					if(!HotelLogic.getInstance().InsertHotel(hotelId, hotelStar) && !(HotelLogic.getInstance().UpdateHotel(hotelId, hotelStar)) )
						errors++;;
				
						if(!(HotelLogic.getInstance().InsertHotelStyle(hotelId, "RO")))
						errors++;;
				}
			}
			
			 nl = doc.getElementsByTagName("Resturant");
				
			 errors = 0;
			for (int i = 0; i < nl.getLength(); i++) {
				if (nl.item(i).getNodeType() == Node.ELEMENT_NODE) {
					Element el = (Element) nl.item(i);
					Place c = new Place(Integer.parseInt(el.getAttribute("PlaceID")), 
							el.getElementsByTagName("nameOfPlace").item(0).getTextContent(),
							el.getElementsByTagName("description").item(0).getTextContent(),
						Integer.parseInt(el.getElementsByTagName("UrlLandmark").item(0).getTextContent().toString()),
							el.getElementsByTagName("PriceLevel").item(0).getTextContent(),
							el.getElementsByTagName("cityOfPlace").item(0).getTextContent(),
						 Integer.parseInt(el.getElementsByTagName("CountryCode").item(0).getTextContent()));
					//System.out.println(el.getElementsByTagName("CountryCode").item(0).getTextContent());
				//	System.out.println(c);
					if (!manipulatePlace(c, entity.Consts.Manipulation.INSERT) && 
							!manipulatePlace(c, entity.Consts.Manipulation.UPDATE))
						errors++;
					Integer resId=Integer.parseInt(el.getAttribute("PlaceID"));
					Integer star=Integer.parseInt(el.getElementsByTagName("starsRating").item(0).getTextContent());
					String style=el.getElementsByTagName("kitchenStyles").item(0).getTextContent();
					if(!(ResturantLogic.getInstance().InsertResturant(resId, star, style)) && !(ResturantLogic.getInstance().editResturantStyle(resId, style)))
							errors++;
				}
			}
			
		//	NodeList nl2 = doc.getElementsByTagName("Distance");

			ArrayList<Place> allPlaces=PlaceLogic.getInstance().getPlace();//get all places
			
			Integer distnace=0;
			Integer placeFrom=0;
			Integer   placeTo=0;
			int i=0;
			for ( i = 0; i < nl.getLength(); i++) {
				if (nl.item(i).getNodeType() == Node.ELEMENT_NODE)
				{
					Element el = (Element) nl.item(i);
					Integer placeId=Integer.parseInt(el.getAttribute("PlaceID"));
					Integer urlMark=Integer.parseInt(el.getElementsByTagName("UrlLandmark").item(0).getTextContent().toString());
					//System.out.println("check place id=-"+placeId+" matk="+urlMark);
				//	System.out.println("placeId="+placeId);
					for(Place p:allPlaces)
					{
						
						if(p.getPlaceId()!=placeId)
						{
							//System.out.println("hii"+p);
							//System.out.println("enterd");
							placeFrom=placeId;
							placeTo=p.getPlaceId();
							//placeTo=placeId;
							distnace=Math.abs((urlMark+p.getUrlLandmark()));//the distance
						//	System.out.println("from="+placeFrom+" to="+placeTo+" dis="+distnace);
						//	System.out.println("insert="+manipulateDistance(placeFrom,placeTo,distnace, entity.Consts.Manipulation.INSERT)+" update="+manipulateDistance(placeFrom,placeTo,distnace, entity.Consts.Manipulation.UPDATE));
							if (!manipulateDistance(placeFrom,placeTo,distnace, entity.Consts.Manipulation.INSERT) && 
									!manipulateDistance(placeFrom,placeTo,distnace, entity.Consts.Manipulation.UPDATE))
								errors++;
							//System.out.println("added");
							//System.out.println("insert="+manipulateDistance(placeFrom,placeTo,distnace, entity.Consts.Manipulation.INSERT)+" update="+manipulateDistance(placeFrom,placeTo,distnace, entity.Consts.Manipulation.UPDATE));
						}
					}
				}
			}
			 allPlaces=PlaceLogic.getInstance().getPlace();//get all places after update with new file
			// System.out.println(allPlaces);
			i=0;
			while(i<allPlaces.size())// cover all the options
			{
				for(Place p:allPlaces)
				{
					
					if(!p.equals(allPlaces.get(i)))
					{
					//	if(p.getPlaceId()==45 || allPlaces.get(i).getPlaceId()==45)
						//	System.out.println(allPlaces.get(i)+" p="+p);
						//System.out.println(allPlaces.get(i)+" p="+p);
						placeFrom=p.getPlaceId();
						placeTo=allPlaces.get(i).getPlaceId();
						distnace=Math.abs((p.getUrlLandmark()+allPlaces.get(i).getUrlLandmark()));//the distance
						if (!manipulateDistance(placeFrom,placeTo,distnace, entity.Consts.Manipulation.INSERT) && 
								!manipulateDistance(placeFrom,placeTo,distnace, entity.Consts.Manipulation.UPDATE))
							errors++;
						
					}
				}
				i++;
			}
			System.out.println((errors == 0) ? "places data imported successfully!" : 
				String.format("places data imported with %d errors!", errors));
			
		} catch (SAXException | IOException | ParserConfigurationException e) {
			e.printStackTrace();
		}
    }
    /*----------------------------------------------------------------------------------------------------------------------*/
    public void importDistanceFromXML(String path) {
    	try {
		    	Document doc = DocumentBuilderFactory.newInstance()
						.newDocumentBuilder().parse(new File(path));
		doc.getDocumentElement().normalize();
		NodeList nl = doc.getElementsByTagName("Distance");
    	ArrayList<Place> allPlaces=PlaceLogic.getInstance().getPlace();//get all places
		Integer distnace=0;
		Integer placeFrom=0;
		Integer   placeTo=0;
		int errors=0;
		int i=0;
		while(i<allPlaces.size())
		{
			for(Place p:allPlaces)
			{
				if(!p.equals(allPlaces.get(i)))
				{
					placeFrom=p.getPlaceId();
					placeTo=allPlaces.get(i).getPlaceId();
					distnace=Math.abs((p.getUrlLandmark()-allPlaces.get(i).getUrlLandmark()));//the distance
					if (!manipulateDistance(placeFrom,placeTo,distnace, entity.Consts.Manipulation.INSERT) && 
							!manipulateDistance(placeFrom,placeTo,distnace, entity.Consts.Manipulation.UPDATE))
						errors++;
				}
				i++;
			}
		}
		System.out.println((errors == 0) ? "places data imported successfully!" : 
			String.format("places data imported with %d errors!", errors));
    	}
		 catch (SAXException | IOException | ParserConfigurationException e)
    	{
			 e.printStackTrace();
    	}
    	
    }
    public boolean manipulateDistance(Integer from,Integer to,Integer distance ,entity.Consts.Manipulation manipulation) {
    	try {
    		Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
    		try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
    				CallableStatement stmt = conn.prepareCall(
    						(manipulation.equals(entity.Consts.Manipulation.UPDATE)) ? 
    								Consts.SQL_UPD_Distance : 
    									(manipulation.equals(entity.Consts.Manipulation.INSERT)) ? 
    											Consts.SQL_Ins_DistancePlaces : 
    												Consts.SQL_DEL_Distance)) {
    			allocateDistanceParams(stmt, from,to, distance, manipulation);
    			stmt.executeUpdate();
    			return true;
    		} catch (SQLException e) {
//    			e.printStackTrace();
    		}
    	} catch (ClassNotFoundException e) {
//    		e.printStackTrace();
    	}
    	
    	return false;
    } 
    
    private void allocateDistanceParams(CallableStatement stmt, Integer from, Integer to, Integer distance,Manipulation manipulation) throws SQLException {
	    	int i = 1;
	    	//	System.out.println("from="+from+" to="+to+" dis="+distance);
	    	if (!manipulation.equals(entity.Consts.Manipulation.UPDATE)) {
	    		//System.out.println("update");
	    		stmt.setInt(i++, from);
	    		stmt.setInt(i++, to);
		    	stmt.setInt(i++, distance);
	    		
	    		if (manipulation.equals(entity.Consts.Manipulation.DELETE))
	    			return;
	    	}
	    	else
	    	{
	    		stmt.setInt(i++, distance);
		    	stmt.setInt(i++, from);
	    		stmt.setInt(i++, to);	
	    	}
	    	
	    	
	}

	public boolean manipulatePlace(Place p, entity.Consts.Manipulation manipulation) {
    	try {
    		Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
    		try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
    				CallableStatement stmt = conn.prepareCall(
    						(manipulation.equals(entity.Consts.Manipulation.UPDATE)) ? 
    								Consts.SQL_UPD_Place : 
    									(manipulation.equals(entity.Consts.Manipulation.INSERT)) ? 
    											Consts.SQL_INS_place : 
    												Consts.SQL_DEL_Place)) {
    			allocatePlaceParams(stmt, p, manipulation);
    			stmt.executeUpdate();
    			return true;
    		} catch (SQLException e) {
//    			e.printStackTrace();
    		}
    	} catch (ClassNotFoundException e) {
//    		e.printStackTrace();
    	}
    	
    	return false;
    }

	private void allocatePlaceParams(CallableStatement stmt, Place p, entity.Consts.Manipulation manipulation) throws SQLException {
	int i = 1;
    	
    	if (!manipulation.equals(entity.Consts.Manipulation.UPDATE)) {
    		stmt.setInt(i++, p.getPlaceId());
    		
    		if (manipulation.equals(entity.Consts.Manipulation.DELETE))
    			return;
    	}
    	//System.out.println("enterd?");
    	stmt.setString(i++, p.getNameOfPlace());
    	
    	if (p.getDescription() == null)
    		stmt.setNull(i++, java.sql.Types.VARCHAR);
    	else
    		stmt.setString(i++, p.getDescription());
    	
    	if (p.getUrlLandmark() == null)
    		stmt.setNull(i++, java.sql.Types.VARCHAR);
    	else
    		stmt.setInt(i++, p.getUrlLandmark());
    	
    	if (p.getPriceLevel() == null)
    		stmt.setNull(i++, java.sql.Types.VARCHAR);
    	else
    		stmt.setString(i++, p.getPriceLevel());
    	
    	if (p.getCity() == null)
    		stmt.setNull(i++, java.sql.Types.VARCHAR);
    	else
    		stmt.setString(i++, p.getCity());
    	
    	if (p.getCountryNumber() == null)
    		stmt.setNull(i++, java.sql.Types.VARCHAR);
    	else
    		stmt.setInt(i++, p.getCountryNumber());
    	
    	if (manipulation.equals(entity.Consts.Manipulation.UPDATE))
    		stmt.setInt(i, p.getPlaceId());
		
	}
}
