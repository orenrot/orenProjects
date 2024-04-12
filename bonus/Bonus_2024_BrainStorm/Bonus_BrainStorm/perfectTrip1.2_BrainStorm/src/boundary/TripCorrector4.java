package boundary;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;

import control.Revivewlogic;
import control.TripLogic;
import control.UserLogic;
import entity.AccomedationsStyle;
import entity.Consts;
import entity.KitchenStylesEnum;
import entity.Place;
import entity.Trip;
import entity.User;
import entity.UserRequest;

import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.RenderingHints;
import java.awt.image.BufferedImage;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.beans.PropertyChangeListener;
import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.beans.PropertyChangeEvent;
import java.awt.Component;
import java.awt.Dimension;
import java.awt.Graphics;

import javax.swing.table.TableModel;


import java.awt.event.HierarchyListener;
import java.awt.event.HierarchyEvent;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.awt.Canvas;
import java.awt.Color;
import java.awt.ScrollPane;
import java.awt.Point;
import java.awt.Scrollbar;
import java.awt.Toolkit;
import java.awt.Button;
import java.awt.Font;

public class TripCorrector4 extends HomePage {
	private JPanel contentPane;
    private JTable tableTrip;
    private     	 JLabel lblNewLabel;
    private  Integer deleteTrip=0;
    private  JButton btnBack;
    private  JButton btnForward ;
    private ArrayList<Trip> allTrips; 
    protected static Integer TripNumber=0;
    protected static Integer TripStatus=-1;
    private Integer correctNumber=0;
    private JTable tablePlacesOrUsers;
	private DefaultTableModel model;
	private DefaultTableModel modelTrip;
	private DefaultTableModel modelPlaceUserInTrip;
	private DefaultTableModel modelRequest;
	private JTable tableTripAddPlaceUser;
	private JScrollPane scrollPanePlaceToTrip ;
	private static Integer optionPlace=-1;// -1 not chosen  0 add 1 delete
	private static Integer optionUser=-1;//-1 not chosen 1 add 0 delete
	private Button buttonPlaces;
	private Button buttonUsers;
	private  Button buttonPlacesInTrip ;
	private   Button buttonUsersNotInTrip;
	private JButton btnRemove;
	private JButton btnAdd;
	private JTextField textFieldCorrect;
	private JScrollPane scrollPaneRequestTrip;
	private JTable tableRequsts;
    private JComboBox comboBoxUserUpdate;
    private ArrayList<UserRequest> usersRequests;
    private  JButton btnUpdateRequst;
    private Button buttonReccomedation;
	private JComboBox comboBoxFilter;
	private JComboBox comboBoxOption;
	private JTextField txtDistance;
	private Button buttonDoReco;
	private JButton btnConfrim;
	private JButton btnDelete;
	private JTextField textEmail;
	private JLabel lbEmailInvinte;
	private JButton btnSend;
	private  JLabel lblUserRequsts;
	private JScrollPane scrollPane;
	
    public TripCorrector4() {
        setTitle("Trip Information");
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        setSize(877, 554);
       
        contentPane = new JPanel() {  //pic
            /**
			 * 
			 */
			private static final long serialVersionUID = 1L;

			public void paintComponent(Graphics g) {  
                    Image img = Toolkit.getDefaultToolkit().getImage(  
                    		TripCorrector4.class.getResource("/boundary/images/background1.png"));  //backgroundImage
                    g.drawImage(img, 0, 0, this.getWidth(), this.getHeight(), this);  
               }  
         };         
        Intiliazie();
        setContentPane(contentPane);
        
       
        
       
    }
    public void Intiliazie()
    {
    	if(HomePage.OptionBy==1)
    	{
    	//	System.out.println("userieri");
    		CreatorUser();
    	}
    	else if(HomePage.OptionBy>1)
    		AdminUser();
      
    }
    public void CreatorUser()
    {
    	//System.out.println("user rnterd="+k);
    	usersRequests= new ArrayList<UserRequest>();
    	String[] columnsplaces = {"Place ID", "Name of place", "description", "urlLandMark", "price level", "city of place"};//Columns of Places
        DefaultTableModel model2= new DefaultTableModel(columnsplaces, 0);
       // panel.setLayout(null);
        tablePlacesOrUsers = new JTable(model2);
        tablePlacesOrUsers.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        tablePlacesOrUsers.setBounds(69, 5, 495, 202);
        String[] columns = {"tripId", "startDate", "endDate", "tripCreator"};
        model = new DefaultTableModel(columns, 0);
        tableTrip = new JTable(model);
        
        allTrips=new ArrayList<Trip>();
        allTrips=TripLogic.getInstance().GetTripByCreator(Login.UserId);
        if(allTrips!=null && !allTrips.isEmpty())
        {	
        	if(FrmCreateTrip.TripId!=null && FrmCreateTrip.TripId!=0  && FrmCreateTrip.MoveToAllInfo==0)
        	{
        		 FrmCreateTrip.MoveToAllInfo=-1;
        		System.out.println(FrmCreateTrip.TripId);
             	System.out.println(allTrips);
            	Trip newTrip=TripLogic.getInstance().specificTrip(FrmCreateTrip.TripId);
            	System.out.println(newTrip);
            	correctNumber=allTrips.indexOf(newTrip);
            	System.out.println("correctNumber="+correctNumber);
            	Integer num1=allTrips.indexOf(FrmCreateTrip.TripId);
            	
            	for (int i = 0; i < allTrips.size(); i++) {
                    if (allTrips.get(i).equals(newTrip)) {
                    	num1 = i;
                        break;
                    }
                    System.out.println(allTrips.get(i));
                    System.out.println(newTrip);
                }

                if (num1 != -1) {
                    System.out.println("Index of the trip: " + num1);
                } else {
                    System.out.println("Trip not found in the array.");
                }
    	        Trip trip=allTrips.get(correctNumber);
    	        Object[] row = {
    	   			 trip.getTripId(),
    	   			 trip.getStartDate(),
    	   			 trip.getEndDate(),
    	   			 trip.getTripCreator()
    	        };
    	        System.out.println(row);
    	        model.addRow(row);
    	        TripNumber=allTrips.get(correctNumber).getTripId();
    	        TripStatus=allTrips.get(correctNumber).getStatus();
    	        System.out.println("TripStatus"+TripStatus);
        	}
        	else
        	{
                model = new DefaultTableModel(columns, 0);
                tableTrip = new JTable(model);
                
              //  allTrips=new ArrayList<Trip>();
               // allTrips=TripLogic.getInstance().get();
                Trip trip=allTrips.get(correctNumber);
                Object[] row = {
           			 trip.getTripId(),
           			 trip.getStartDate(),
           			 trip.getEndDate(),
           			 trip.getTripCreator()
                };
                
                model.addRow(row);
                TripNumber=allTrips.get(correctNumber).getTripId();
                TripStatus=allTrips.get(correctNumber).getStatus();
        	}
	        contentPane=new JPanel() {  
	            /**
				 * 
				 */
				private static final long serialVersionUID = 1L;
	
				public void paintComponent(Graphics g) {  
	                    Image img = Toolkit.getDefaultToolkit().getImage(  
	                    		TripCorrector4.class.getResource("/boundary/images/background1.png"));  //backgroundImage
	                    g.drawImage(img, 0, 0, this.getWidth(), this.getHeight(), this);  
	               }  
	         }; 
	         contentPane.setLayout(null);
	         
	         
	        System.out.println("TripStatus"+TripStatus);
	        if(TripStatus==null)
	        	TripStatus=-1;
	        SameOrderObjects();
    	}
        else
        {
        	JOptionPane.showMessageDialog(null, "no trips found that you do", "trips", JOptionPane.PLAIN_MESSAGE);	
        	System.out.println(deleteTrip);
        	if(deleteTrip>=1)
        	{
        		scrollPane.setVisible(false);
        		scrollPanePlaceToTrip.setVisible(false);
	        	btnConfrim.setVisible(false);
				 btnDelete.setVisible(false);
				 lbEmailInvinte.setVisible(false);
			 	 textEmail.setVisible(false);
			 	   btnSend.setVisible(false);
			 	  txtDistance.setVisible(false);
	         		buttonDoReco.setVisible(false);
	         		tableTripAddPlaceUser.setVisible(false);
	         		tablePlacesOrUsers.setVisible(false);
	         		textFieldCorrect.setVisible(false);
	         	    
	         		tableTrip.setVisible(false);
	         	    lblNewLabel.setVisible(false);
	         	    btnBack.setVisible(false);
	         	     btnForward.setVisible(false);
	         		buttonPlaces.setVisible(false);;
	         		 buttonUsers.setVisible(false);;
	         		 buttonPlacesInTrip.setVisible(false); ;
	         		 buttonUsersNotInTrip.setVisible(false);;
	         		 btnRemove.setVisible(false);;
	         		btnAdd.setVisible(false);;
	         		 textFieldCorrect.setVisible(false);;
	         		tableRequsts.setVisible(false);;
	         	     comboBoxUserUpdate.setVisible(false);;
	         	    btnUpdateRequst.setVisible(false);;
	         	   buttonReccomedation.setVisible(false);;
	         		 comboBoxFilter.setVisible(false);;
	         		 comboBoxOption.setVisible(false);;
	         		 btnSend.setVisible(false);;
	         	   lblUserRequsts.setVisible(false);;
        	}
        }
    }
    
    
    
    
    public void AdminUser()
    {
    	usersRequests= new ArrayList<UserRequest>();
   	 	String[] columnsplaces = {"Place ID", "Name of place", "description", "urlLandMark", "price level", "city of place"};//Columns of Places
        DefaultTableModel model2= new DefaultTableModel(columnsplaces, 0);
       // panel.setLayout(null);
        tablePlacesOrUsers = new JTable(model2);
        tablePlacesOrUsers.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        tablePlacesOrUsers.setBounds(69, 5, 495, 202);
        String[] columns = {"tripId", "startDate", "endDate", "tripCreator"};
        model = new DefaultTableModel(columns, 0);
        tableTrip = new JTable(model);
       // tableTrip.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        allTrips=new ArrayList<Trip>();
        allTrips=TripLogic.getInstance().getTrip();
        System.out.println("correctNumber="+correctNumber);
        System.out.println("all="+allTrips);
        if(allTrips!=null && !allTrips.isEmpty())//have values
        {
	        Trip trip=allTrips.get(correctNumber);
	        Object[] row = {
	   			 trip.getTripId(),
	   			 trip.getStartDate(),
	   			 trip.getEndDate(),
	   			 trip.getTripCreator()
	        };
	        
	        model.addRow(row);
	        tableTrip.setModel(model);
	        tableTrip.repaint();
	        System.out.println("Table Contents:");
	        for (int i = 0; i < model.getRowCount(); i++) {
	            for (int j = 0; j < tableTrip.getColumnCount(); j++) {
	                System.out.print(tableTrip.getValueAt(i, j) + "\t");
	            }
	            System.out.println();
	        }
	        TripNumber=allTrips.get(correctNumber).getTripId();
	        TripStatus=allTrips.get(correctNumber).getStatus();
	        contentPane=new JPanel() {  
	            /**
				 * 
				 */
				private static final long serialVersionUID = 1L;
	
				public void paintComponent(Graphics g) {  
	                    Image img = Toolkit.getDefaultToolkit().getImage(  
	                    		TripCorrector4.class.getResource("/boundary/images/background1.png"));  //backgroundImage
	                    g.drawImage(img, 0, 0, this.getWidth(), this.getHeight(), this);  
	               }  
	         }; 
	         contentPane.setLayout(null);
	         System.out.println("admin");
	        SameOrderObjects();
        }
        else
        {
        	JOptionPane.showMessageDialog(null, "no trips found ", "trips", JOptionPane.PLAIN_MESSAGE);	
        	System.out.println(deleteTrip);
        	if(deleteTrip>=1)
        	{
        		scrollPane.setVisible(false);
        		scrollPanePlaceToTrip.setVisible(false);
	        	btnConfrim.setVisible(false);
				 btnDelete.setVisible(false);
				 lbEmailInvinte.setVisible(false);
			 	 textEmail.setVisible(false);
			 	   btnSend.setVisible(false);
			 	  txtDistance.setVisible(false);
	         		buttonDoReco.setVisible(false);
	         		tableTripAddPlaceUser.setVisible(false);
	         		tablePlacesOrUsers.setVisible(false);
	         		textFieldCorrect.setVisible(false);
	         	    
	         		tableTrip.setVisible(false);
	         	    lblNewLabel.setVisible(false);
	         	    btnBack.setVisible(false);
	         	     btnForward.setVisible(false);
	         		buttonPlaces.setVisible(false);;
	         		 buttonUsers.setVisible(false);;
	         		 buttonPlacesInTrip.setVisible(false); ;
	         		 buttonUsersNotInTrip.setVisible(false);;
	         		 btnRemove.setVisible(false);;
	         		btnAdd.setVisible(false);;
	         		 textFieldCorrect.setVisible(false);;
	         		tableRequsts.setVisible(false);;
	         	     comboBoxUserUpdate.setVisible(false);;
	         	    btnUpdateRequst.setVisible(false);;
	         	   buttonReccomedation.setVisible(false);;
	         		 comboBoxFilter.setVisible(false);;
	         		 comboBoxOption.setVisible(false);;
	         		 btnSend.setVisible(false);;
	         	   lblUserRequsts.setVisible(false);;
        	}
        }
     
    }
    
    private void SameOrderObjects() {
    	System.out.println("entered");
    	  btnAdd = new JButton("add");
          btnAdd.addActionListener(new ActionListener() {
          	public void actionPerformed(ActionEvent e) {
          		if(optionPlace==0)//addPlace
          		{
          			if(buttonDoReco.isVisible()==false)
          			{
	          			System.out.println("enter place add");
	          			Integer tripNum=allTrips.get(correctNumber).getTripId();
	          			Integer idPlace=Integer.parseInt(tableTripAddPlaceUser.getValueAt(tableTripAddPlaceUser.getSelectedRow(), 0).toString());
	          			TripLogic.getInstance().addPlaceToTrip(tripNum, idPlace);
	  						refreshPlaces();
          			}
          			else
  	        		{	
          				Integer tripNum=allTrips.get(correctNumber).getTripId();
  	        			Integer idPlace=Integer.parseInt(tableTripAddPlaceUser.getValueAt(tableTripAddPlaceUser.getSelectedRow(), 0).toString());
  	        			TripLogic.getInstance().addPlaceToTrip(tripNum, idPlace);
  	        			Integer dist=Integer.parseInt(txtDistance.getText().toString());
  						refreshPlacesReccomedationsMode(TripNumber,dist);
          			}
          				
          		}
          		if(optionUser==1)//add user
          		{
          			Integer tripNum=allTrips.get(correctNumber).getTripId();
          			Integer idUser=Integer.parseInt(tableTripAddPlaceUser.getValueAt(tableTripAddPlaceUser.getSelectedRow(), 0).toString());
          			TripLogic.getInstance().addUserToTrip(tripNum, idUser);
  						refreshUsersInTrip();
          		}
          	}
          });
          btnAdd.setBounds(21, 349, 89, 23);
          if(TripStatus<2)
        	  btnAdd.setVisible(true);
          else
        	  btnAdd.setVisible(false);
          contentPane.add(btnAdd);
          
    	 lblUserRequsts = new JLabel("user requests");//so will added in the start
         lblUserRequsts.setFont(new Font("Tahoma", Font.PLAIN, 14));
         lblUserRequsts.setBackground(Color.WHITE);
         lblUserRequsts.setOpaque(true);
         lblUserRequsts.setBounds(337, 325, 98, 29);
         contentPane.add(lblUserRequsts);
         
    	 lblNewLabel = new JLabel("the default is places in trip");
         lblNewLabel.setBounds(25, 136, 156, 14);
         lblNewLabel.setVisible(true);
         contentPane.add(lblNewLabel);
         
    	comboBoxUserUpdate = new JComboBox();
        comboBoxUserUpdate.setBounds(455, 464, 108, 21);
        contentPane.add(comboBoxUserUpdate);
        
        btnRemove = new JButton("remove");
        btnRemove.addActionListener(new ActionListener() {
        	public void actionPerformed(ActionEvent e) {
        		if(optionPlace==1)//removePlace
        		{
        			Integer tripNum=allTrips.get(correctNumber).getTripId();
        			Integer idPlace=Integer.parseInt(tableTripAddPlaceUser.getValueAt(tableTripAddPlaceUser.getSelectedRow(), 0).toString());
        			TripLogic.getInstance().removePlaceToTrip(tripNum, idPlace);
						refreshPlaces();
        		}
        		else if(optionUser==0)//removeUser
        		{
        			Integer tripNum=allTrips.get(correctNumber).getTripId();
        			Integer idUser=Integer.parseInt(tableTripAddPlaceUser.getValueAt(tableTripAddPlaceUser.getSelectedRow(), 0).toString());
        			TripLogic.getInstance().removeUserFromTrip(tripNum, idUser);
        			refreshUsersInTrip();
        		}
        	}
        });
        btnRemove.setBounds(120, 349, 89, 23);
        btnRemove.setVisible(false);
        contentPane.add(btnRemove);
        
         btnUpdateRequst = new JButton("Update Request");
        btnUpdateRequst.addActionListener(new ActionListener() {
        	public void actionPerformed(ActionEvent e) {
        		if(!comboBoxUserUpdate.getSelectedItem().toString().equals("Choose user"))
	          	{
	          		Integer userId=Integer.parseInt(comboBoxUserUpdate.getSelectedItem().toString());
	          		System.out.println(userId+" tripNumer="+TripNumber);
	          		if(UserLogic.getInstance().updateRequestToUser(userId, TripNumber,"NoEmail"))
	          		{
	          			JOptionPane.showMessageDialog(null, "completed", "user requset",JOptionPane.PLAIN_MESSAGE);
	          			refreshUserRequstsForTrip();
	          		}
	          		else
	          			 JOptionPane.showMessageDialog(null, "fail", "user requset",JOptionPane.PLAIN_MESSAGE);
	          	}
        		else
        			JOptionPane.showMessageDialog(null, "choose user", "user requset",JOptionPane.PLAIN_MESSAGE);
        	}
        });
        btnUpdateRequst.setBounds(586, 464, 124, 21);
        contentPane.add(btnUpdateRequst);
        
        
        scrollPane = new JScrollPane(tableTrip);
       scrollPane.setBounds(21, 27, 689, 77);
       contentPane.add(scrollPane);
       
        btnBack = new JButton("back");
        btnBack.addActionListener(new ActionListener() {
        	public void actionPerformed(ActionEvent e) {
        		if(correctNumber>0)
        		{
        			correctNumber--;
        			TripNumber=allTrips.get(correctNumber).getTripId();
        		   TripStatus=allTrips.get(correctNumber).getStatus();
        			TripShownUpdate();
        			refreshPlaces();
        			textFieldCorrect.setText(""+correctNumber);
        			if(TripStatus<2)
        			{
        				 btnConfrim.setVisible(true);
        				 btnDelete.setVisible(true);
        		         lbEmailInvinte.setVisible(true);
        		         textEmail.setVisible(true);
        		         btnSend.setVisible(true);
        		       //  btnRemove.setVisible(false);
      	           		txtDistance.setVisible(false);
      	           		buttonDoReco.setVisible(false);
        		         
        			}
        			else
        			{
        				 btnConfrim.setVisible(false);
        				 btnDelete.setVisible(false);
        				 lbEmailInvinte.setVisible(false);
        			 	 textEmail.setVisible(false);
        			 	   btnSend.setVisible(false);
        			 	  txtDistance.setVisible(false);
         	           		buttonDoReco.setVisible(false);
         	           		//btnRemove.setVisible(false);
        			}
        			refreshUserRequstsForTrip();
        		}
        		
        	}
        });
        btnBack.setBounds(25, 422, 89, 23);
        contentPane.add(btnBack);
       
       textFieldCorrect = new JTextField();
       textFieldCorrect.setEnabled(false);
       textFieldCorrect.setBounds(135, 423, 86, 20);
       textFieldCorrect.setText(""+correctNumber);
       contentPane.add(textFieldCorrect);
       textFieldCorrect.setColumns(10);
       
        btnForward = new JButton("forward");
        btnForward.addActionListener(new ActionListener() {
        	public void actionPerformed(ActionEvent e) {
        		if(correctNumber<allTrips.size()-1)
        		{
        			correctNumber++;
        			TripNumber=allTrips.get(correctNumber).getTripId();
        			TripStatus=allTrips.get(correctNumber).getStatus();
        			TripShownUpdate();
        			refreshPlaces();
        			textFieldCorrect.setText(""+correctNumber);
        			if(TripStatus<2)
        			{
        				 btnConfrim.setVisible(true);
        				 btnDelete.setVisible(true);
        		         lbEmailInvinte.setVisible(true);
        		         textEmail.setVisible(true);
        		         btnSend.setVisible(true);
        		         btnAdd.setVisible(false);
     	           		//btnRemove.setVisible(false);
     	           		txtDistance.setVisible(false);
     	           		buttonDoReco.setVisible(false);
        		       
        		        	
        			}
        			else
        			{
        				 btnConfrim.setVisible(false);
        				 btnDelete.setVisible(false);
        				 lbEmailInvinte.setVisible(false);
        			 	 textEmail.setVisible(false);
        			 	   btnSend.setVisible(false);
        			 	  txtDistance.setVisible(false);
       	           		buttonDoReco.setVisible(false);
       	           		//btnRemove.setVisible(false);
        			}
        			refreshUserRequstsForTrip();
        		}
        		else
        			btnForward.setVisible(false);
        	
        	}
        });
        btnForward.setBounds(245, 422, 89, 23);
        contentPane.add(btnForward);
        
        String[] columns = {"tripId", "startDate", "endDate", "tripCreator"};
        
       modelPlaceUserInTrip = new DefaultTableModel(columns, 0);
       tableTripAddPlaceUser = new JTable(modelPlaceUserInTrip);
       tableTripAddPlaceUser.setBounds(65, 136, 687, 153);
       tableTripAddPlaceUser.setVisible(true);
      
       refreshPlaces();
      
       scrollPanePlaceToTrip = new JScrollPane(tableTripAddPlaceUser);
       scrollPanePlaceToTrip.setBounds(25, 155, 687, 153);
       contentPane.add(scrollPanePlaceToTrip);
       
    	 btnConfrim = new JButton("ConfrimTrip");
    	 btnConfrim.addActionListener(new ActionListener() {
    	 	public void actionPerformed(ActionEvent e) {
    	 		Integer requestCounter=TripLogic.getInstance().CountRequestsForTrip(TripNumber);
    	 		if(requestCounter>0)
    	 		{
    	 			JOptionPane.showMessageDialog(null, "There are still open requests", "no coframtion trip",JOptionPane.PLAIN_MESSAGE);
    	 		}
    	 		else if(requestCounter==0 && TripLogic.getInstance().getUsersInTrip(TripNumber)!=null && !TripLogic.getInstance().getUsersInTrip(TripNumber).isEmpty() 
    	 				&& TripLogic.getInstance().getPlacesInTrip(TripNumber)!=null && !TripLogic.getInstance().getPlacesInTrip(TripNumber).isEmpty() )
    	 		{
    	 			if(TripLogic.getInstance().updateTripStatus(TripNumber, 2))// 2 is the trip is done
    	 			{
    	 				JOptionPane.showMessageDialog(null, "There trip is confrim", "coframtion trip",JOptionPane.PLAIN_MESSAGE);
    	 			}
    	 			else
    	 				JOptionPane.showMessageDialog(null, "error", "error",JOptionPane.ERROR_MESSAGE);
    	 		}
    	 		else if((TripLogic.getInstance().getUsersInTrip(TripNumber)==null || TripLogic.getInstance().getUsersInTrip(TripNumber).isEmpty() ) && (TripLogic.getInstance().getPlacesInTrip(TripNumber)==null || TripLogic.getInstance().getPlacesInTrip(TripNumber).isEmpty()))
    	 		{
    	 			JOptionPane.showMessageDialog(null, "no users and places in trip", "no coframtion trip",JOptionPane.PLAIN_MESSAGE);
    	 		}
    	 		else if(TripLogic.getInstance().getUsersInTrip(TripNumber)==null || TripLogic.getInstance().getUsersInTrip(TripNumber).isEmpty() )
    	 		{
    	 			JOptionPane.showMessageDialog(null, "no users in trip", "no coframtion trip",JOptionPane.PLAIN_MESSAGE);
    	 		}
    	 		else if(TripLogic.getInstance().getPlacesInTrip(TripNumber)==null || TripLogic.getInstance().getPlacesInTrip(TripNumber).isEmpty() )
    	 		{
    	 			JOptionPane.showMessageDialog(null, "no places in trip", "no coframtion trip",JOptionPane.PLAIN_MESSAGE);
    	 		}
    	 	}
    	 });
         btnConfrim.setOpaque(true);
         btnConfrim.setBackground(Color.WHITE);
         btnConfrim.setForeground(Color.GREEN);
         btnConfrim.setBounds(720, 132, 131, 23);
         if(TripStatus<2)
         {
        	 btnConfrim.setVisible(true);
         }
         else
        	 btnConfrim.setVisible(false);
         contentPane.add(btnConfrim);
         
         btnDelete = new JButton("Destroy my work");
         btnDelete.addActionListener(new ActionListener() {
         	public void actionPerformed(ActionEvent e) {
         		if(TripStatus<2)
         		{
         			if(TripLogic.getInstance().removeTrip(TripNumber))
         			{
         				System.out.println("HomePage.OptionBy="+HomePage.OptionBy);
         				JOptionPane.showMessageDialog(null, "deleted Trip", "delete trip",JOptionPane.PLAIN_MESSAGE);
         				if(HomePage.OptionBy==2)
         				{
         					correctNumber=0;
         					  textFieldCorrect.setText(""+correctNumber);
         					deleteTrip++;
         					System.out.println("removed no reviwes");
         					//AdminUser();
         					 allTrips=new ArrayList<Trip>();
         				     allTrips=TripLogic.getInstance().getTrip();
         				    
         				     if(allTrips==null || allTrips.isEmpty() )
         				    	AdminUser();
         					
         				    if(allTrips!=null && !allTrips.isEmpty())
         					{
         						System.out.println("TripNumber+"+TripNumber+"+TripStatus"+TripStatus);
         						TripNumber=allTrips.get(correctNumber).getTripId();
         	        		   TripStatus=allTrips.get(correctNumber).getStatus();
         						TripShownUpdate();
         						refreshPlaces();
         						refreshUserRequstsForTrip();
         						if(TripStatus<2)
         	        			{
         	        				 btnConfrim.setVisible(true);
         	        				 btnDelete.setVisible(true);
         	        		         lbEmailInvinte.setVisible(true);
         	        		         textEmail.setVisible(true);
         	        		         btnSend.setVisible(true);
         	        		       //  btnRemove.setVisible(false);
         	      	           		txtDistance.setVisible(false);
         	      	           		buttonDoReco.setVisible(false);
         	        		         
         	        			}
         	        			else
         	        			{
         	        				 btnConfrim.setVisible(false);
         	        				 btnDelete.setVisible(false);
         	        				 lbEmailInvinte.setVisible(false);
         	        			 	 textEmail.setVisible(false);
         	        			 	   btnSend.setVisible(false);
         	        			 	  txtDistance.setVisible(false);
         	         	           		buttonDoReco.setVisible(false);
         	         	           		//btnRemove.setVisible(false);
         	        			}
         					}
         				}
         				else if(HomePage.OptionBy==1)
         				{
         					correctNumber=0;
         					  textFieldCorrect.setText(""+correctNumber);
         					deleteTrip++;
         					//CreatorUser();
         				
         					 allTrips=new ArrayList<Trip>();
          			        allTrips=TripLogic.getInstance().GetTripByCreator(Login.UserId);
          			     
          			        if(allTrips==null || allTrips.isEmpty() )
       			        	CreatorUser();
          					//System.out.println("after delete"+deleteTrip);
          					if(allTrips!=null && !allTrips.isEmpty())
          					{
          						TripNumber=allTrips.get(correctNumber).getTripId();
           	        		   TripStatus=allTrips.get(correctNumber).getStatus();
          						TripShownUpdate();
          						refreshPlaces();
          						refreshUserRequstsForTrip();
          						if(TripStatus<2)
          	        			{
          	        				 btnConfrim.setVisible(true);
          	        				 btnDelete.setVisible(true);
          	        		         lbEmailInvinte.setVisible(true);
          	        		         textEmail.setVisible(true);
          	        		         btnSend.setVisible(true);
          	        		       //  btnRemove.setVisible(false);
          	      	           		txtDistance.setVisible(false);
          	      	           		buttonDoReco.setVisible(false);
          	        		         
          	        			}
          	        			else
          	        			{
          	        				 btnConfrim.setVisible(false);
          	        				 btnDelete.setVisible(false);
          	        				 lbEmailInvinte.setVisible(false);
          	        			 	 textEmail.setVisible(false);
          	        			 	   btnSend.setVisible(false);
          	        			 	  txtDistance.setVisible(false);
          	         	           		buttonDoReco.setVisible(false);
          	         	           		//btnRemove.setVisible(false);
          	        			}
          					}
         				}
         			}
         			else
         			{	
         				System.out.println(TripNumber);
         				boolean re=Revivewlogic.getInstance().deleteReviewByID(TripNumber);
         				System.out.println(re);
         				if(re)
         				{
         					if(TripLogic.getInstance().removeTrip(TripNumber))
                 			{
                 				JOptionPane.showMessageDialog(null, "deleted Trip", "delete trip",JOptionPane.PLAIN_MESSAGE);
                 				if(HomePage.OptionBy==2)
                 				{
                 					System.out.println("removed with reviwes");
                 					correctNumber=0;
                 					  textFieldCorrect.setText(""+correctNumber);
                 					deleteTrip++;
                 					//AdminUser();
                 					 allTrips=new ArrayList<Trip>();
                 				     allTrips=TripLogic.getInstance().getTrip();
                 				   
                 				     if(allTrips==null || allTrips.isEmpty() )
                 				    	AdminUser();
                 				    
                 					if(allTrips!=null && !allTrips.isEmpty())
                 					{
                 						System.out.println("TripNumber+"+TripNumber+"+TripStatus"+TripStatus);
                 						TripNumber=allTrips.get(correctNumber).getTripId();
                 	        		   TripStatus=allTrips.get(correctNumber).getStatus();
                 						TripShownUpdate();
                 						refreshPlaces();
                 						refreshUserRequstsForTrip();
                 						if(TripStatus<2)
                 	        			{
                 	        				 btnConfrim.setVisible(true);
                 	        				 btnDelete.setVisible(true);
                 	        		         lbEmailInvinte.setVisible(true);
                 	        		         textEmail.setVisible(true);
                 	        		         btnSend.setVisible(true);
                 	        		       //  btnRemove.setVisible(false);
                 	      	           		txtDistance.setVisible(false);
                 	      	           		buttonDoReco.setVisible(false);
                 	        		         
                 	        			}
                 	        			else
                 	        			{
                 	        				 btnConfrim.setVisible(false);
                 	        				 btnDelete.setVisible(false);
                 	        				 lbEmailInvinte.setVisible(false);
                 	        			 	 textEmail.setVisible(false);
                 	        			 	   btnSend.setVisible(false);
                 	        			 	  txtDistance.setVisible(false);
                 	         	           		buttonDoReco.setVisible(false);
                 	         	           		//btnRemove.setVisible(false);
                 	        			}
                 					}
                 				}
                 				else if(HomePage.OptionBy==1)
                 				{
                 					correctNumber=0;
                 					  textFieldCorrect.setText(""+correctNumber);
                 					deleteTrip++;
                 					//CreatorUser();
                 				    allTrips=new ArrayList<Trip>();
                 			        allTrips=TripLogic.getInstance().GetTripByCreator(Login.UserId);
                 			       
                 			        if(allTrips==null || allTrips.isEmpty() )
                 			        	CreatorUser();
                 					//System.out.println("after delete"+deleteTrip);
                 					if(allTrips!=null && !allTrips.isEmpty())
                 					{
                 						TripNumber=allTrips.get(correctNumber).getTripId();
                  	        		   TripStatus=allTrips.get(correctNumber).getStatus();
                 						TripShownUpdate();
                 						refreshPlaces();
                 						refreshUserRequstsForTrip();
                 						if(TripStatus<2)
                 	        			{
                 	        				 btnConfrim.setVisible(true);
                 	        				 btnDelete.setVisible(true);
                 	        		         lbEmailInvinte.setVisible(true);
                 	        		         textEmail.setVisible(true);
                 	        		         btnSend.setVisible(true);
                 	        		       //  btnRemove.setVisible(false);
                 	      	           		txtDistance.setVisible(false);
                 	      	           		buttonDoReco.setVisible(false);
                 	        		         
                 	        			}
                 	        			else
                 	        			{
                 	        				 btnConfrim.setVisible(false);
                 	        				 btnDelete.setVisible(false);
                 	        				 lbEmailInvinte.setVisible(false);
                 	        			 	 textEmail.setVisible(false);
                 	        			 	   btnSend.setVisible(false);
                 	        			 	  txtDistance.setVisible(false);
                 	         	           		buttonDoReco.setVisible(false);
                 	         	           		//btnRemove.setVisible(false);
                 	        			}
                 					}
                 				}
                 			}
         				}
         				else
         					JOptionPane.showMessageDialog(null, "error in delete Trip", "delete trip",JOptionPane.ERROR_MESSAGE);
         			}
         		}
         	}
         });
         btnDelete.setForeground(Color.RED);
         btnDelete.setBounds(720, 95, 131, 23);
         if(TripStatus<2)
        	 btnDelete.setVisible(true);
         else
        	 btnDelete.setVisible(false);
         contentPane.add(btnDelete);
         
    	  
           
          
           
           buttonPlaces = new Button("places not in trip");
           buttonPlaces.addActionListener(new ActionListener() {
           	public void actionPerformed(ActionEvent e) {
           		 btnAdd.setVisible(true);
                   btnRemove.setVisible(false);
                   comboBoxOption.setVisible(true);
           		txtDistance.setVisible(false);
           		buttonDoReco.setVisible(false);
           		optionPlace=0;
           		optionUser=-1;
           		refreshPlaces();
           	}
           });
           buttonPlaces.setBounds(21, 110, 108, 19);
           contentPane.add(buttonPlaces);
           
           buttonUsers = new Button("users in trip");
           buttonUsers.addActionListener(new ActionListener() {
           	public void actionPerformed(ActionEvent e) {
           		optionUser=0;
           		optionPlace=-1;
           		refreshUsersInTrip();
           		  comboBoxOption.setVisible(false);
           		  comboBoxFilter.setVisible(false);
           			txtDistance.setVisible(false);
   	        		buttonDoReco.setVisible(false);
                 // btnRemove.setVisible(true);
                  btnAdd.setVisible(false);
           	}
           });
           buttonUsers.setBounds(248, 110, 69, 19);
           contentPane.add(buttonUsers);
           
           buttonPlacesInTrip = new Button("places in trip");
           buttonPlacesInTrip.addActionListener(new ActionListener() {
           	public void actionPerformed(ActionEvent e) {
           		optionPlace=1;
           		optionUser=-1;
           		  comboBoxOption.setVisible(false);
           		  comboBoxFilter.setVisible(false);
                  // btnRemove.setVisible(true);
                   btnAdd.setVisible(false);
           		txtDistance.setVisible(false);
           		buttonDoReco.setVisible(false);
           		refreshPlaces();
           	}
           });
           buttonPlacesInTrip.setBounds(135, 110, 108, 19);
           contentPane.add(buttonPlacesInTrip);
           
           comboBoxFilter = new JComboBox<Object>();
   		comboBoxFilter.setVisible(false);
   		comboBoxFilter.addActionListener(new ActionListener() {
   			public void actionPerformed(ActionEvent e) {
   				//System.out.println(comboBoxFilter.getSelectedItem());
   				if(comboBoxOption.getSelectedItem().toString().equals("AccomedationStyle")&& comboBoxFilter.getSelectedItem()!=null  && comboBoxFilter!=null && !comboBoxFilter.getSelectedItem().equals("choose"))//style
   				{
   					String[] columns = {"Place ID", "Name of place", "description", "urlLandMark", "price level", "city of place"};
   					modelPlaceUserInTrip = new DefaultTableModel(columns, 0);
   					while(modelPlaceUserInTrip!=null && modelPlaceUserInTrip.getRowCount()!=0)
   					{
   						modelPlaceUserInTrip.removeRow(0);
   					}
   					
   					//modelPlaceUserInTrip.addRow(columns);
   					ArrayList<Place> places = TripLogic.getInstance().getPlaceByAccomedationStyle(TripNumber,comboBoxFilter.getSelectedItem().toString());// get all places
   			        for (Place p : places) {
   			            Object[] row = {
   			            		p.getPlaceId(),
   			                    p.getNameOfPlace(),
   			                    p.getDescription(),
   			                    p.getUrlLandmark(),
   			                    p.getPriceLevel(),
   			                    p.getCity()
   			            };
   			            try {
   			                // Add the row directly to the table model
   			            	modelPlaceUserInTrip.addRow(row);
   			            } catch (Exception ex) {
   			                ex.printStackTrace();
   			               // JOptionPane.showMessageDialog(this, "Error adding row to table: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
   			            }
   			            tableTripAddPlaceUser.setModel(modelPlaceUserInTrip);
   			            tableTripAddPlaceUser.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
   			        }
   				}
   				else if(comboBoxOption.getSelectedItem().toString().equals("Kitchen") && comboBoxFilter.getSelectedItem()!=null  && comboBoxFilter!=null && !comboBoxFilter.getSelectedItem().equals("choose"))//style
   				{
   					String[] columns = {"Place ID", "Name of place", "description", "urlLandMark", "price level", "city of place"};
   					modelPlaceUserInTrip = new DefaultTableModel(columns, 0);
   					while(modelPlaceUserInTrip!=null && modelPlaceUserInTrip.getRowCount()!=0)
   					{
   						modelPlaceUserInTrip.removeRow(0);
   					}
   					
   					//modelPlaceUserInTrip.addRow(columns);
   					ArrayList<Place> places = TripLogic.getInstance().getPlaceByKitchen(TripNumber,comboBoxFilter.getSelectedItem().toString());// get all places
   			        for (Place p : places) {
   			            Object[] row = {
   			            		p.getPlaceId(),
   			                    p.getNameOfPlace(),
   			                    p.getDescription(),
   			                    p.getUrlLandmark(),
   			                    p.getPriceLevel(),
   			                    p.getCity()
   			            };
   			            try {
   			                // Add the row directly to the table model
   			            	modelPlaceUserInTrip.addRow(row);
   			            } catch (Exception ex) {
   			                ex.printStackTrace();
   			               // JOptionPane.showMessageDialog(this, "Error adding row to table: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
   			            }
   		            	tableTripAddPlaceUser.setModel(modelPlaceUserInTrip);
   		            	tableTripAddPlaceUser.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
   			        }
   				}
   			}
   		});
   		comboBoxFilter.setBounds(220, 375, 116, 22);
   		contentPane.add(comboBoxFilter);
   		
   		comboBoxOption = new JComboBox<Object>();
   		comboBoxOption.addActionListener(new ActionListener() {
   			public void actionPerformed(ActionEvent e) {
   				comboBoxFilter.removeAllItems();//remove all items
   				comboBoxFilter.setVisible(false);
   				if(comboBoxOption.getSelectedItem().toString().equals("Kitchen"))
   				{
   					comboBoxFilter.setVisible(true);
   					/*	for(PriceLevel price:PriceLevel.values())
   					comboBoxFilter.addItem(price.toString());* to do a query that group by kitchens or show only specific kitchen*/ 
   					comboBoxFilter.addItem("choose");
   					for(KitchenStylesEnum kitchen:KitchenStylesEnum.values())
   					comboBoxFilter.addItem(kitchen.toString());
   				}
   				else if(comboBoxOption.getSelectedItem().toString().equals("priceLevel"))
   				{
   				/*	for(PriceLevel price:PriceLevel.values())
   					comboBoxFilter.addItem(price.toString());* to do a query of high to low*/ 
   					String[] columns = {"Place ID", "Name of place", "description", "urlLandMark", "price level", "city of place"};
   					modelPlaceUserInTrip = new DefaultTableModel(columns, 0);
   					while(modelPlaceUserInTrip!=null && modelPlaceUserInTrip.getRowCount()!=0)
   					{
   						modelPlaceUserInTrip.removeRow(0);
   					}
   					
   					//modelPlaceUserInTrip.addRow(columns);
   					ArrayList<Place> places = TripLogic.getInstance().getPlaceByPriceLevel(TripNumber);// get all places
   			        for (Place p : places) {
   			            Object[] row = {
   			            		p.getPlaceId(),
   			                    p.getNameOfPlace(),
   			                    p.getDescription(),
   			                    p.getUrlLandmark(),
   			                    p.getPriceLevel(),
   			                    p.getCity()
   			            };
   			            try {
   			                // Add the row directly to the table model
   			            	modelPlaceUserInTrip.addRow(row);
   			            } catch (Exception ex) {
   			                ex.printStackTrace();
   			               // JOptionPane.showMessageDialog(this, "Error adding row to table: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
   			            }
   			            tableTripAddPlaceUser.setModel(modelPlaceUserInTrip);
   			            tableTripAddPlaceUser.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
   			        }
   				}
   				else if(comboBoxOption.getSelectedItem().toString().equals("AccomedationStyle"))
   				{
   					comboBoxFilter.setVisible(true);
   					comboBoxFilter.addItem("choose");
   					for(AccomedationsStyle acmStyle:AccomedationsStyle.values())
   					comboBoxFilter.addItem(acmStyle.toString());
   				}
   			}
   		});
   		comboBoxOption.setModel(new DefaultComboBoxModel<Object>(new String[] {"choose filter", "Kitchen", "priceLevel", "AccomedationStyle"}));
   		comboBoxOption.setBounds(21, 375, 179, 22);
   		contentPane.add(comboBoxOption);
   		
           buttonUsersNotInTrip = new Button("users not in trip");
           buttonUsersNotInTrip.addActionListener(new ActionListener() {
           	public void actionPerformed(ActionEvent e) {
           		optionUser=1;
           		optionPlace=-1;
           		refreshUsersInTrip();
           		 btnAdd.setVisible(true);
           		  btnRemove.setVisible(false);
           		  comboBoxOption.setVisible(false);
           		  comboBoxFilter.setVisible(false);
           			txtDistance.setVisible(false);
   	        		buttonDoReco.setVisible(false);
           	}
           });
         
           scrollPaneRequestTrip = new JScrollPane((Component) null);
           scrollPaneRequestTrip.setBounds(445, 318, 373, 130);
           contentPane.add(scrollPaneRequestTrip);
           String[] columnsRequest = {"User ID", "TripId", "description"};//Columns of Places
           modelRequest = new DefaultTableModel(columnsRequest, 0);
           tableRequsts = new JTable(modelRequest);
           tableRequsts.setVisible(true);
           tableRequsts.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
           scrollPaneRequestTrip.setViewportView(tableRequsts);
           buttonUsersNotInTrip.setBounds(323, 110, 89, 19);
           refreshUserRequstsForTrip();
           contentPane.add(buttonUsersNotInTrip);
           
           buttonReccomedation = new Button("Reccomedation Mode");
           buttonReccomedation.addActionListener(new ActionListener() {
           	public void actionPerformed(ActionEvent e) {
           		optionPlace=0;
           		optionUser=-1;
           		if(TripStatus<2)
           		{
	           		btnAdd.setVisible(true);
	           		btnRemove.setVisible(false);
	           		txtDistance.setVisible(true);
	           		buttonDoReco.setVisible(true);
	           		comboBoxOption.setVisible(false);
	           		comboBoxFilter.setVisible(false);
           		}
           		else
           		{
           			btnAdd.setVisible(false);
	           		btnRemove.setVisible(false);
	           		txtDistance.setVisible(true);
	           		buttonDoReco.setVisible(true);
	           		comboBoxOption.setVisible(false);
	           		comboBoxFilter.setVisible(false);
           		}
           	}
           });
           buttonReccomedation.setBounds(420, 110, 135, 19);
           contentPane.add(buttonReccomedation);
          
           txtDistance = new JTextField();
	   		txtDistance.setBounds(210, 376, 86, 20);
	   		txtDistance.setVisible(false);
	   		contentPane.add(txtDistance);
	   		txtDistance.setColumns(10);
   	   
   		buttonDoReco = new Button("click");
   	    buttonDoReco.addActionListener(new ActionListener() {
           	public void actionPerformed(ActionEvent e) {
           		try {
   					Integer dist=Integer.parseInt(txtDistance.getText().toString());
   						refreshPlacesReccomedationsMode(TripNumber,dist);
   				}
   				catch(Exception ex)
   				{
   			  		JOptionPane.showMessageDialog(null, " error", " error",JOptionPane.ERROR_MESSAGE);
   				}
           	}
           });
	   	    buttonDoReco.setBounds(342, 375, 89, 19);
	   	    buttonDoReco.setVisible(false);
	   	 contentPane.add(buttonDoReco);
           
          
           
           textEmail = new JTextField();
           textEmail.setBounds(722, 197, 119, 20);
           if(TripStatus<2)
        	   textEmail.setVisible(true);
           else
        	   textEmail.setVisible(false);
           contentPane.add(textEmail);
           textEmail.setColumns(10);
           
           lbEmailInvinte = new JLabel("Email to invite");
           lbEmailInvinte.setBounds(722, 172, 89, 14);
           if(TripStatus<2)
        	   lbEmailInvinte.setVisible(true);
           else
        	   lbEmailInvinte.setVisible(false);
           contentPane.add(lbEmailInvinte);
           
           btnSend = new JButton("send");
           btnSend.addActionListener(new ActionListener() {
           	public void actionPerformed(ActionEvent e) {
           		if(textEmail.getText().isEmpty())
           		{
           			JOptionPane.showMessageDialog(null, "email is empty", "email requset",JOptionPane.PLAIN_MESSAGE);
           		}
           		else
           		{
           					//create request by email
           			        String emailRegex = "^[a-zA-Z0-9_+&*-]+(?:\\.[a-zA-Z0-9_+&*-]+)*@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,7}$";
           			        boolean goodEmail= textEmail.getText().matches(emailRegex);
           			        if(goodEmail==false)
           			        	JOptionPane.showMessageDialog(null, "email is good? :"+goodEmail, "email requset",JOptionPane.ERROR_MESSAGE);
           			        else
           			        {  //update trip status and added request
           			        	if(UserLogic.getInstance().addRequestToUser(Login.UserId, TripNumber, "join trip", textEmail.getText().toString()) && TripLogic.getInstance().updateTripStatus(TripNumber, 1) )
           			        	{
           			        		JOptionPane.showMessageDialog(null, "requset added successfully", " requset",JOptionPane.PLAIN_MESSAGE);
           			        	}
           			        	else
           			        		JOptionPane.showMessageDialog(null, "requset error", " requset",JOptionPane.ERROR_MESSAGE);
           			        }
           			      
           			        
           		}
           		
           	}
           });
           if(TripStatus<2)
        	   btnSend.setVisible(true);
           else
        	   btnSend.setVisible(false);
           btnSend.setBounds(729, 227, 89, 23);
           contentPane.add(btnSend);
		
	}
	public void TripShownUpdate()
    {
		System.out.println("updated");
		System.out.println("correctNumber="+correctNumber+"allTrips.size()"+allTrips.size());
    	  String[] columns = {"tripId",  "startDate", "endDate", "tripCreator"};
    	  modelTrip = new DefaultTableModel(columns, 0);
    	 // System.out.println(modelTrip.);
		   while(modelTrip.getRowCount()!=0)
			{
			   modelTrip.removeRow(0);
			}
    	  Trip trip=allTrips.get(correctNumber);
          Object[] row = {
     			 trip.getTripId(),
     			 trip.getStartDate(),
     			 trip.getEndDate(),
     			 trip.getTripCreator()
          };
          System.out.println("trip="+trip);
          if(correctNumber==allTrips.size())
          {
        	  btnForward.setVisible(false);
          }
          else
        	  btnForward.setVisible(true);
          if(correctNumber==0)
          {
        	  btnBack.setVisible(false);
          }
          else
        	  btnBack.setVisible(true);
         
          tableTrip.repaint();
          modelTrip.addRow(row);
          tableTrip.setModel(modelTrip);
          tableTrip.repaint();
          System.out.println(tableTrip);
          tableTrip.setVisible(true);
    }
    
    private void refreshPlaces() {
		String[] columns = {"Place ID", "Name of place", "description", "urlLandMark", "price level", "city of place"};
		modelPlaceUserInTrip = new DefaultTableModel(columns, 0);
		while(modelPlaceUserInTrip!=null && modelPlaceUserInTrip.getRowCount()!=0)
		{
			modelPlaceUserInTrip.removeRow(0);
		}
		ArrayList<Place> places=new ArrayList<Place>();

		if(optionPlace==0)
			 places = TripLogic.getInstance().getPlacesNotInTrip(allTrips.get(correctNumber).getTripId());// get all places
		else
			places  = TripLogic.getInstance().getFullPlacesInTrip(allTrips.get(correctNumber).getTripId());// get all places
	        for (Place p : places) {
	            Object[] row = {
	                p.getPlaceId(),
	                p.getNameOfPlace(),
	                p.getDescription(),
	                p.getUrlLandmark(),
	                p.getPriceLevel(),
	                p.getCity()
	            };
	            try {
	            	modelPlaceUserInTrip.addRow(row);
	            } catch (Exception ex) {
	                ex.printStackTrace();
	   
	            }
	        }
	        tableTripAddPlaceUser.setModel(modelPlaceUserInTrip);
	        tableTripAddPlaceUser.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
	        if(optionPlace==1 && places.size()<=1)//can not delete the last place in trip
	        {
	        	btnRemove.setVisible(false);
	        }
	        else
	        {
	        	if(TripStatus<2 && !btnAdd.isVisible())
	        		btnRemove.setVisible(true);
	        	else
	        		btnRemove.setVisible(false);
	        }
	}
    
    private void refreshUsersInTrip() {
		String[] columns = {"User ID", "firstName", "lastName", "email"};
		modelPlaceUserInTrip = new DefaultTableModel(columns, 0);
		while(modelPlaceUserInTrip!=null && modelPlaceUserInTrip.getRowCount()!=0)
		{
			modelPlaceUserInTrip.removeRow(0);
		}
		
		ArrayList<User> Users =new ArrayList<User>();
		if(optionUser==0)
			 Users = TripLogic.getInstance().getUsersInTrip(allTrips.get(correctNumber).getTripId());// get all users
		else
			Users = TripLogic.getInstance().getUsersNotInTrip(allTrips.get(correctNumber).getTripId());// get all users
	        for (User p : Users) {
	            Object[] row = {
	                p.getUserId(),
	                p.getFirstName(),
	                p.getLastName(),
	                p.getEmail()
	                  };
	            try {
	            	modelPlaceUserInTrip.addRow(row);
	            } catch (Exception ex) {
	                ex.printStackTrace();
	   
	            }
	        }
	        tableTripAddPlaceUser.setModel(modelPlaceUserInTrip);
	        tableTripAddPlaceUser.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
	      //  System.out.println("hi"+Users.size()+ "Option="+optionUser);
	        if(optionUser==0 && Users.size()<=1)//can not delete the last person in trip
	        {
	        	btnRemove.setVisible(false);
	        }
	        else
	        {
	        	if(TripStatus<2)
	        	{
	        		btnRemove.setVisible(true);
	        	}
	        	else
	        		btnRemove.setVisible(false);
	        }
	        	
	}
    
    public void refreshUserRequstsForTrip()
    {
	    	usersRequests.removeAll(usersRequests);
	    	TripLogic.getInstance().getRequestForTrip(allTrips.get(correctNumber).getTripId());
	    	String[] columns = {"Trip ID", "User id", "description"};
	    	modelRequest = new DefaultTableModel(columns, 0);
			while(modelRequest!=null && modelRequest.getRowCount()!=0)
			{
				modelRequest.removeRow(0);
			}
			ArrayList<UserRequest> userReq=new ArrayList<UserRequest>();
			
			userReq=TripLogic.getInstance().getRequestForTrip(allTrips.get(correctNumber).getTripId()); 
			usersRequests.addAll(userReq);//add all to userRequsts
		        for (UserRequest p : userReq) {
		            Object[] row = {
		                p.getTripId(),
		                p.getUserId(),
		                p.getDescribe(),
		            };
		            try {
		            	modelRequest.addRow(row);
		            } catch (Exception ex) {
		                ex.printStackTrace();
		   
		            }
		        }
		        tableRequsts.setModel(modelRequest);
		        tableTripAddPlaceUser.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
		        refreshComboBoxOptions(userReq);
		        if(usersRequests.isEmpty())// no requsts
		        {
		        	scrollPaneRequestTrip.setVisible(false);
		        	tableRequsts.setVisible(false);
		        	comboBoxUserUpdate.setVisible(false);
		        	 btnUpdateRequst.setVisible(false);
		        	 lblUserRequsts.setVisible(false);
		        }
		        else
		        {
		        	if(TripStatus<2)
		        	{
			        	scrollPaneRequestTrip.setVisible(true);
			        	tableRequsts.setVisible(true);
			        	comboBoxUserUpdate.setVisible(true);
			        	 btnUpdateRequst.setVisible(true);
			        	 lblUserRequsts.setVisible(true);
		        	}
		        	else
		        	{
		        		//System.out.println("entered trip status=2");
		        	 	scrollPaneRequestTrip.setVisible(true);
			        	tableRequsts.setVisible(true);
			        	comboBoxUserUpdate.setVisible(false);
			        	 btnUpdateRequst.setVisible(false);
			        	 lblUserRequsts.setVisible(true);
		        	}
		        	
		        }
    }



    private void refreshComboBoxOptions(ArrayList<UserRequest> userReq) {
    	comboBoxUserUpdate.removeAllItems();
    	comboBoxUserUpdate.addItem("Choose user");
		for(UserRequest userRequstsUpdate:userReq)
		{
			comboBoxUserUpdate.addItem(userRequstsUpdate.getUserId());;
		}
		
	}
    
	public void refreshPlacesReccomedationsMode(Integer tripNum,Integer distanceMax)
	{
		
		String[] columns = {"Place ID", "NameOfPlace", "Description", "UrlLandmark","PriceLevel","City"};
		modelPlaceUserInTrip = new DefaultTableModel(columns, 0);
		while(modelPlaceUserInTrip!=null && modelPlaceUserInTrip.getRowCount()!=0)
		{
			modelPlaceUserInTrip.removeRow(0);
		}System.out.println("endik");
		
		String result="";
		
		ArrayList<Place> places = TripLogic.getInstance().getPlaceReccomedations(tripNum,distanceMax);// get all places
		//System.out.println(places);
        for (Place p : places) {
            Object[] row = {
                p.getPlaceId(),
                p.getNameOfPlace(),
                p.getDescription(),
                p.getUrlLandmark(),
                p.getPriceLevel(),
                p.getCity()
            };
            result+=p.toString()+"";//all revenues
            try {
                // Add the row directly to the table model
            	modelPlaceUserInTrip.addRow(row);
            	//System.out.println(row);
            } catch (Exception ex) {
                ex.printStackTrace();
               // JOptionPane.showMessageDialog(this, "Error adding row to table: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
            }
            tableTripAddPlaceUser.setModel(modelPlaceUserInTrip);
        }
        if(places!=null && !places.isEmpty())//have places
        {
	        String fileName ="Reccomedation Report";
	        if (fileName != null && !fileName.trim().isEmpty()) {//write to word file
	            try (BufferedWriter writer = new BufferedWriter(new FileWriter(fileName + ".docx"))) {
	                writer.write(result);//write the string to the word file
	                writer.flush();//end the write and create a files
	                JOptionPane.showMessageDialog(null, "Word file created!");//created file
	            } catch (IOException ex) {
	                ex.printStackTrace();
	                JOptionPane.showMessageDialog(null, "fail in creating Word file!");//Can't Create file
	            }
	        }
        }
        else
        	JOptionPane.showMessageDialog(null, "no reccomedation found", " reccomedation",JOptionPane.PLAIN_MESSAGE);
	}
	
	public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
        	TripCorrector4 frame = new TripCorrector4();
            frame.setVisible(true);
        });
    }
}
