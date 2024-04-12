//package boundary;
//
//import java.awt.EventQueue;
//import java.awt.Font;
//import java.awt.Graphics;
//import java.awt.Image;
//import java.awt.Toolkit;
//import java.awt.event.ActionEvent;
//import java.awt.event.ActionListener;
//import java.util.ArrayList;
//
//import javax.swing.JFrame;
//import javax.swing.JPanel;
//import javax.swing.border.EmptyBorder;
//import javax.swing.table.DefaultTableModel;
//
//import control.TripLogic;
//import entity.Place;
//
//import javax.swing.JTextField;
//import javax.swing.JLabel;
//import javax.swing.JComboBox;
//import javax.swing.JButton;
//
//public class WriteReview extends HomePage {
//	private JLabel lblTripNumber;
//
//	private JPanel contentPane;
//	private JTextField textField;
//	private DefaultTableModel model;
//
//	/**
//	 * Launch the application.
//	 */
//	public static void main(String[] args) {
//		EventQueue.invokeLater(new Runnable() {
//			public void run() {
//				try {
//					WriteReview frame = new WriteReview();
//					frame.setVisible(true);
//				} catch (Exception e) {
//					e.printStackTrace();
//				}
//			}
//		});
//	}
//
//	/**
//	 * Create the frame.
//	 */
//	public WriteReview() {
//		
//		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
//		setBounds(100, 100, 450, 300);
//		contentPane = new JPanel();
//		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
//
//		setContentPane(contentPane);
//		contentPane.setLayout(null);
//		
//		JLabel lblNewLabel = new JLabel("Add your Review");
//		lblNewLabel.setBounds(10, 79, 111, 16);
//		contentPane.add(lblNewLabel);
//		
//		textField = new JTextField();
//		textField.setBounds(183, 79, 96, 19);
//		contentPane.add(textField);
//		textField.setColumns(10);
//		
//		contentPane = new JPanel();
//		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
//		contentPane = new JPanel() {  //pic
//            /**
//			 * 
//			 */
//			private static final long serialVersionUID = 1L;
//
//			public void paintComponent(Graphics g) {  
//                    Image img = Toolkit.getDefaultToolkit().getImage(  
//                    		FrmTrip2.class.getResource("/boundary/images/background1.png"));  //backgroundImage
//                    g.drawImage(img, 0, 0, this.getWidth(), this.getHeight(), this);  
//               }  
//         };         
// 		setContentPane(contentPane);	
//	
//
//		JComboBox 	comboBoxTripNumber = new JComboBox<Object>();
//		comboBoxTripNumber.addItem("choose trip number");
//		comboBoxTripNumber.setFont(new Font("Tahoma", Font.PLAIN, 14));
//		comboBoxTripNumber.setBounds(183, 36, 179, 21);
//		comboBoxTripNumber.addActionListener(new ActionListener() {
//			public void actionPerformed(ActionEvent e) {
//
//					while(model.getRowCount()!=0)
//					{
//						model.removeRow(0);
//					}
//	
//					ArrayList<Place> places = TripLogic.getInstance().getPlacesNotInTrip(Integer.parseInt(comboBoxTripNumber.getSelectedItem().toString()));// get all places
//				        for (Place p : places)
//				        {
//				            Object[] row = {
//				            		p.getPlaceId(),
//				                    p.getNameOfPlace(),
//				                    p.getDescription(),
//				                    p.getUrlLandmark(),
//				                    p.getPriceLevel(),
//				                    p.getCity()
//				            };
//				            try {
//				                // Add the row directly to the table model
//				                model.addRow(row);
//				            } catch (Exception ex) {
//				                ex.printStackTrace();
//				               // JOptionPane.showMessageDialog(this, "Error adding row to table: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
//				            }
//				        }
//				comboBoxTripNumber.removeAllItems();
//				ArrayList<Integer> placesId = TripLogic.getInstance().getPlacesInTrip(Integer.parseInt(comboBoxTripNumber.getSelectedItem().toString()));// get all places
//				for(Integer id:placesId)
//					comboBoxTripNumber.addItem(id);
//			}});
//
//		contentPane.add(comboBoxTripNumber);
//		
//		lblTripNumber = new JLabel("choose trip number");
//		lblTripNumber.setFont(new Font("Tahoma", Font.PLAIN, 18));
//		lblTripNumber.setBounds(10, 30, 163, 30);
//		ArrayList<Integer> tripNumber=TripLogic.getInstance().GetTripNumbers();
//		while(!tripNumber.isEmpty())
//		{
//			tripNumber.get(0);
//			comboBoxTripNumber.addItem(tripNumber.get(0));
//			tripNumber.remove(0);
//		}
//		contentPane.add(lblTripNumber);
//		
//		JButton btnNewButton = new JButton("Add Review");
//		btnNewButton.setBounds(302, 210, 85, 21);
//		contentPane.add(btnNewButton);
//	}
//}

package boundary;

import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Date;
import java.awt.Graphics;
import java.awt.Toolkit;
import java.awt.Image;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.border.EmptyBorder;
import javax.swing.table.DefaultTableModel;

import control.Revivewlogic;
import control.TripLogic;
import control.UserLogic;
import entity.Place;
import entity.review;

import javax.swing.JTextField;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JComboBox;
import javax.swing.JButton;
import javax.swing.DefaultComboBoxModel;

public class WriteReview extends HomePage {
	private JLabel lblTripNumber;
	private JTable tableRevews;
	private JPanel contentPane;
	private JTextField textField;
	private DefaultTableModel model;
	private JComboBox<Object> comboBoxTripNumber;
	private  JComboBox comboBoxScore;
	private JTable tablereviews;
	private JTextField textField_1;
	private JTextField txtDescribe;
	private JLabel lblNewLabel_1;
	private JLabel lblNewLabel_2;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					WriteReview frame = new WriteReview();
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
	public WriteReview() {
	
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 733, 504);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		contentPane = new JPanel() {  //pic
            /**
			 * 
			 */
			private static final long serialVersionUID = 1L;

			public void paintComponent(Graphics g) {  
                    Image img = Toolkit.getDefaultToolkit().getImage(  
                    		WriteReview.class.getResource("/boundary/images/background1.png"));  //backgroundImage
                    g.drawImage(img, 0, 0, this.getWidth(), this.getHeight(), this);  
               }  
         };         
         Intiliazie();
		
}
	
	private void Intiliazie() {
		contentPane.setLayout(null);
		 String[] columns = {"Place ID", "Name of place", "description", "urlLandMark", "price level", "city of place"};
	     model = new DefaultTableModel(columns, 0);
	     
	
	     tablereviews = new JTable(model);
	     tablereviews.setFont(new Font("Tahoma", Font.PLAIN, 12));
	     tablereviews.setForeground(Color.BLACK);
	     tablereviews.setBackground(Color.LIGHT_GRAY);
	     tablereviews.setBounds(67, 131, 562, 276);
		comboBoxTripNumber = new JComboBox<Object>();
		comboBoxTripNumber.addItem("choose trip number");
		comboBoxTripNumber.setFont(new Font("Tahoma", Font.PLAIN, 14));
		comboBoxTripNumber.setBounds(183, 36, 179, 21);
		comboBoxTripNumber.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			    // Clear existing rows from the table model
			    model.setRowCount(0);

			    // Retrieve the selected trip number
			    int selectedTripNumber = Integer.parseInt(comboBoxTripNumber.getSelectedItem().toString());

			    // Retrieve reviews for the selected trip number
			    ArrayList<Place> reviews = TripLogic.getInstance().getFullPlacesInTrip(selectedTripNumber);

			    // Populate the table model with the retrieved reviews
			    for (Place p : reviews) {
			        Object[] rowData = {
			        		 p.getPlaceId(),
				                p.getNameOfPlace(),
				                p.getDescription(),
				                p.getUrlLandmark(),
				                p.getPriceLevel(),
				                p.getCity()
			            
			        };
			        model.addRow(rowData);
			    }
			}



			});
		
		lblNewLabel_1 = new JLabel("choose place to review");
		lblNewLabel_1.setBackground(new Color(255, 255, 255));
		lblNewLabel_1.setFont(new Font("Tahoma", Font.PLAIN, 16));
		lblNewLabel_1.setBounds(0, 182, 210, 30);
		contentPane.add(lblNewLabel_1);

		contentPane.add(comboBoxTripNumber);
		
		lblTripNumber = new JLabel("choose trip number");
		lblTripNumber.setFont(new Font("Tahoma", Font.PLAIN, 18));
		lblTripNumber.setBounds(10, 30, 163, 30);
		
		contentPane.add(lblTripNumber);
		contentPane.add(tablereviews);
		setContentPane(contentPane);		

		addTripNumberThatCanAddReviews();
		
	    JScrollPane scrollPane = new JScrollPane(tablereviews);
	    scrollPane.setBounds(65, 225, 562, 181);
	    contentPane.add(scrollPane);
	    
	    JLabel lblNewLabel = new JLabel("enter your descrption");
	    lblNewLabel.setFont(new Font("Tahoma", Font.PLAIN, 18));
	    lblNewLabel.setBounds(10, 66, 168, 17);
	    contentPane.add(lblNewLabel);
	    
	    txtDescribe = new JTextField();
	    txtDescribe.setBounds(193, 67, 204, 20);
	    contentPane.add(txtDescribe);
	    txtDescribe.setColumns(10);
	    
	    lblNewLabel_2 = new JLabel("score");
	    lblNewLabel_2.setFont(new Font("Tahoma", Font.PLAIN, 16));
	    lblNewLabel_2.setBounds(10, 94, 163, 21);
	    contentPane.add(lblNewLabel_2);
	    
	    comboBoxScore = new JComboBox();
	    comboBoxScore.setModel(new DefaultComboBoxModel(new String[] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"}));
	    comboBoxScore.setBounds(190, 95, 65, 22);
	    contentPane.add(comboBoxScore);
	    
	    JButton btnaddreview = new JButton("Add");
	    btnaddreview.setFont(new Font("Tahoma", Font.PLAIN, 14));
	    btnaddreview.addActionListener(new ActionListener() {
	        public void actionPerformed(ActionEvent e) {
	            // Check if a trip and a review are selected
	            if (comboBoxTripNumber.getSelectedItem().equals("choose trip number") || tablereviews.getSelectedRow() == -1 || txtDescribe.getText().toString()==null ) {
	                JOptionPane.showMessageDialog(null, "Please select a trip and a place to add", "Error", JOptionPane.ERROR_MESSAGE);
	                return; // Exit the method if selection is invalid
	            }
	            
	            // Get the selected review ID from the table
	            int reviewID=Revivewlogic.getInstance().nextReviewId();
	           // int reviewID = Integer.parseInt(tablereviews.getValueAt(tablereviews.getSelectedRow(), 0).toString());   
	            int score = Integer.parseInt(comboBoxScore.getSelectedItem().toString());//score between 0 and 10 kollel
	            String comment=txtDescribe.getText();
	           // String comment = tablereviews.getValueAt(tablereviews.getSelectedRow(), 2).toString();
	            int placeID = Integer.parseInt(tablereviews.getValueAt(tablereviews.getSelectedRow(), 0).toString());//place id
	          //  int userID = Integer.parseInt(tablereviews.getValueAt(tablereviews.getSelectedRow(), 4).toString()); we haveUserId
	            int tripNum = Integer.parseInt(comboBoxTripNumber.getSelectedItem().toString());
	            DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd/MM/yyyy");
	            LocalDate currentDate = LocalDate.now();
	            String formattedDate = currentDate.format(formatter);
	           Date writeDate;
			try {
				writeDate = new SimpleDateFormat("dd/MM/yyyy").parse(formattedDate);
				System.out.println("reviewID="+reviewID+ " comment="+comment+" placeID="+placeID+" tripNum="+tripNum+" UserId="+Login.UserId);
	            // Call the method to add review to trip
				//boolean canWrite=
	            boolean success = TripLogic.getInstance().addReviewToTrip(reviewID, score, comment, placeID, Login.UserId, tripNum,writeDate);
	            // Check if the review was successfully added to the trip
	            if (success) {
	                JOptionPane.showMessageDialog(null, "Review added to the trip successfully", "Success", JOptionPane.INFORMATION_MESSAGE);
	            } else {
	                JOptionPane.showMessageDialog(null, "Failed to add review to the trip", "Error", JOptionPane.ERROR_MESSAGE);
	            }
			} catch (ParseException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
				 JOptionPane.showMessageDialog(null, "Failed to add review to the trip", "Error", JOptionPane.ERROR_MESSAGE);
			}
	            
	        }
	    });
	    btnaddreview.setBounds(407, 67, 85, 21);
	    contentPane.add(btnaddreview);
	    
	 
	    
	   


	}
	public void addTripNumberThatCanAddReviews()
	{
		if(Login.UserId!=null && Login.UserId!=0)
		{
			ArrayList<Integer> tripNumber=UserLogic.getInstance().canWriteReview(Login.UserId);
			while(!tripNumber.isEmpty())
			{
				tripNumber.get(0);
				comboBoxTripNumber.addItem(tripNumber.get(0));
				tripNumber.remove(0);
			}
		}
		else
			 JOptionPane.showMessageDialog(null, "no user found", "Error", JOptionPane.ERROR_MESSAGE);
	}
}
