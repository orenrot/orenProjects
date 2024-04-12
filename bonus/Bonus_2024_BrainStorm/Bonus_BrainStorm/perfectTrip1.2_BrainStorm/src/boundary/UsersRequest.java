package boundary;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.border.EmptyBorder;
import javax.swing.table.DefaultTableModel;

import control.Revivewlogic;
import control.TripLogic;
import control.UserLogic;
import entity.Trip;
import entity.User;
import entity.UserRequest;
import entity.review;

import javax.swing.JTextField;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JOptionPane;

import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Toolkit;

import javax.swing.JComboBox;
import javax.swing.JTable;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.awt.event.ActionEvent;

public class UsersRequest extends HomePage {

	private JPanel contentPane;
	private JTextField txtRequest;
	private JTable table;
	private JButton btnRequest;
	private JLabel lblRequest;
	private JComboBox comboBoxTripID;
	private JButton btnTripYouIn;
	private JButton btnTripYouMay;
	private DefaultTableModel model;
	private static Integer InOut=-1;//1 in 0 out
	private  JScrollPane scrollPane;
	private ArrayList<Integer> tripNumbers;
	private JLabel lblJoin;
	private JComboBox comboBoxTripsJoin;
	private JButton btnJoin;
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					UsersRequest frame = new UsersRequest();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public UsersRequest() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 708, 516);
		contentPane = new JPanel() {  //pic
            /**
			 * 
			 */
			private static final long serialVersionUID = 1L;

			public void paintComponent(Graphics g) {  
                    Image img = Toolkit.getDefaultToolkit().getImage(  
                    		UsersRequest.class.getResource("/boundary/images/background1.png"));  //backgroundImage
                    g.drawImage(img, 0, 0, this.getWidth(), this.getHeight(), this);  
               }  
         };         
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));

		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		Intiliazie();
	//contentPane.add(table);
	}
	 private void Intiliazie() {
		 txtRequest = new JTextField();
			txtRequest.setBounds(207, 210, 130, 20);
			contentPane.add(txtRequest);
			txtRequest.setColumns(10);
			
			 btnRequest = new JButton("to enter request");
			 btnRequest.addActionListener(new ActionListener() {
			 	public void actionPerformed(ActionEvent e) {
			 		if(comboBoxTripID!=null && comboBoxTripID.getSelectedItem()!=null)
			 		{
				 		String userRequestDesribe=txtRequest.getText();
					 	try {	
					 			Integer tripId=Integer.parseInt(comboBoxTripID.getSelectedItem().toString());
					 			if(UserLogic.getInstance().addRequestToUser(Login.UserId, tripId, userRequestDesribe,"NoEmail"))
					 			{
					 			//	ImageIcon icon = new ImageIcon("boundary/images/success.png");
					 		        
					 		        // Create a JLabel with the image
					 		   //     JLabel label = new JLabel(icon);
					 			 //  JOptionPane.showMessageDialog(null,label, "success enter your request",JOptionPane.PLAIN_MESSAGE);
					 				JOptionPane.showMessageDialog(null, "success enter your request");
					 			}
					 				
					 		}
				 			catch(NumberFormatException ex)
				 			{
				 			   JOptionPane.showMessageDialog(null, "The input provided is not a  number.");
				 			}
			 		}
			 		else
			 			JOptionPane.showMessageDialog(null, "not added your request");
			 			
			 	}
			 });
			btnRequest.setFont(new Font("Tahoma", Font.PLAIN, 14));
			btnRequest.setBounds(347, 207, 140, 23);
			contentPane.add(btnRequest);
			
			 lblRequest = new JLabel("your request");
			lblRequest.setFont(new Font("Tahoma", Font.PLAIN, 14));
			lblRequest.setBounds(10, 208, 81, 20);
			contentPane.add(lblRequest);
			
			 comboBoxTripID = new JComboBox();
			comboBoxTripID.setBounds(98, 209, 99, 22);
			contentPane.add(comboBoxTripID);
			tripNumbers=new ArrayList<Integer>();
			 btnTripYouIn = new JButton("Trip You In");
			 btnTripYouIn.setFont(new Font("Tahoma", Font.PLAIN, 14));
			btnTripYouIn.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					InOut=1;
					refreshInOrNotInTrip();
				}
			});
			btnTripYouIn.setBounds(10, 23, 119, 23);
			contentPane.add(btnTripYouIn);
			
			btnTripYouMay = new JButton("Trip You may join");
			btnTripYouMay.setFont(new Font("Tahoma", Font.PLAIN, 14));
			btnTripYouMay.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					InOut=0;
					refreshInOrNotInTrip();
				}
			});
			btnTripYouMay.setBounds(139, 23, 163, 23);
			contentPane.add(btnTripYouMay);
			
		    String[] columns = {"tripId", "descriptation", "rating", "startDate", "endDate", "tripCreator"};
	        model = new DefaultTableModel(columns, 0);
	         
			table = new JTable(model);
			table.setFont(new Font("Tahoma", Font.PLAIN, 14));
			table.setEnabled(false);
			table.setBounds(24, 296, 431, -206);
	        table.setVisible(true);
	        scrollPane = new JScrollPane(table);
	        scrollPane.setEnabled(false);
	        scrollPane.setBounds(10, 74, 536, 112);
	        scrollPane.setVisible(true);
	        contentPane.add(scrollPane);
	        
	        lblJoin = new JLabel("Trips you asked to join");
	        lblJoin.setFont(new Font("Tahoma", Font.PLAIN, 14));
	        lblJoin.setBounds(10, 255, 155, 48);
	        contentPane.add(lblJoin);
	        
	        btnJoin = new JButton("Join");
	        btnJoin.addActionListener(new ActionListener() {
	        	public void actionPerformed(ActionEvent e) {
	        		if(comboBoxTripsJoin.getSelectedItem()!=null && comboBoxTripsJoin.getSelectedItem().toString().isEmpty())
	        		{
	        			JOptionPane.showMessageDialog(null, "choose a trip to update", " requset",JOptionPane.ERROR_MESSAGE);
	        		}
	        		else
	        		{
	        			Integer tripNum=Integer.parseInt(comboBoxTripsJoin.getSelectedItem().toString());
	        			if(TripLogic.getInstance().addUserToTrip(tripNum, Login.UserId))
	        			{
	        				ArrayList<UserRequest> userRequstTrip=UserLogic.getInstance().requestToJoinFullInfo(tripNum);
	        				Trip thisTrip=TripLogic.getInstance().specificTrip(tripNum);
	        				UserRequest thisUserRquest = null;
	        				for(UserRequest req:userRequstTrip)
	        				{
	        					if(req.getUserId()==thisTrip.getTripCreator())
	        					{
	        						thisUserRquest=req;
	        					}
	        				}
	        				System.out.println("hii"+thisUserRquest);
	        				
	        				if(thisUserRquest!=null && UserLogic.getInstance().updateRequestToUser(thisTrip.getTripCreator(), tripNum, thisUserRquest.getEmail()))
	        					JOptionPane.showMessageDialog(null, "added you to trip and the request updated", " trip request",JOptionPane.PLAIN_MESSAGE);
	        				resfreshTripNumbers();
	        				
	        			}
	        			else
	        				JOptionPane.showMessageDialog(null, "error", " trip request",JOptionPane.ERROR_MESSAGE);
	        			
	        		}
	        	}
	        });
	        btnJoin.setBounds(339, 270, 89, 23);
	        contentPane.add(btnJoin);
		
	        
	        comboBoxTripsJoin = new JComboBox();
	        comboBoxTripsJoin.setBounds(175, 270, 130, 22);
	        resfreshTripNumbers();
	        contentPane.add(comboBoxTripsJoin);
	        
	        
	}

	private void resfreshTripNumbers() {
		if(Login.UserId!=null)
		{
			comboBoxTripsJoin.removeAllItems();
			comboBoxTripsJoin.addItem("choose Trip");
			String userEmail = UserLogic.getInstance().UserEmail(Login.UserId);
			if(userEmail!=null)
			{
				ArrayList<Integer> tripJoin=UserLogic.getInstance().requestToJoin(Login.UserId,userEmail );
				if(!tripJoin.isEmpty())//no trips found
				{
					for(Integer tripNum:tripJoin)
						comboBoxTripsJoin.addItem(""+tripNum);
				}
				else
				{
					comboBoxTripsJoin.setVisible(false);
					btnJoin.setVisible(false);
					lblJoin.setVisible(false);
				}
			}
			else
			{
				comboBoxTripsJoin.setVisible(false);
				btnJoin.setVisible(false);
				lblJoin.setVisible(false);
			}
		}
		else
		{
			comboBoxTripsJoin.setVisible(false);
			btnJoin.setVisible(false);
			lblJoin.setVisible(false);
		}
		
	}

	private void refreshInOrNotInTrip() {
			String[] columns = {"tripId","startDate", "endDate", "tripCreator"};
			model = new DefaultTableModel(columns, 0);
			while(model!=null && model.getRowCount()!=0)
			{
				model.removeRow(0);
			}
			System.out.println("entered userid="+Login.UserId);
			tripNumbers.removeAll(tripNumbers);
			ArrayList<Trip> trips =new ArrayList<Trip>();
			if(InOut==1)
				trips = UserLogic.getInstance().requestForTripIn(Login.UserId);//userId that login in
			else
				trips = UserLogic.getInstance().requestForTripNotIn(Login.UserId);//userId that login in
		        for (Trip trip : trips) {
		        	  Object[] row = {
		          			 trip.getTripId(),
		          			 trip.getStartDate(),
		          			 trip.getEndDate(),
		          			 trip.getTripCreator()
		               };
		        	  tripNumbers.add(trip.getTripId());
		        	//  System.out.println("trip="+trip);
		            try {
		            	model.addRow(row);
		            } catch (Exception ex) {
		                ex.printStackTrace();
		   
		            }
		        }
		        comboBoxTripID.removeAllItems();
		        if(tripNumbers!=null)
		    	for(int i=0 ;i<tripNumbers.size();i++)
				{
					comboBoxTripID.addItem(tripNumbers.get(i));
				}
		        table.setModel(model);
		       // scrollPane.setVisible(true);
		}
}
