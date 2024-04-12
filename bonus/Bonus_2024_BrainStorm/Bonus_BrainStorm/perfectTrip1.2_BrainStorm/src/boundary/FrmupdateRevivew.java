package boundary;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.table.DefaultTableModel;

import control.Revivewlogic;
import control.TripLogic;
import entity.Place;
import entity.review;

import javax.swing.JLabel;
import javax.swing.JOptionPane;

import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Toolkit;
import java.util.ArrayList;
import java.util.Date;

import javax.swing.JComboBox;
import javax.swing.JButton;
import javax.swing.JTextField;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import java.awt.Color;
import java.awt.event.ActionListener;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.awt.event.ActionEvent;

public class FrmupdateRevivew extends HomePage {

	private JPanel contentPane;
	private JTextField textDescribe;
	private JTable tableReview;
	private JComboBox comboBoxRevivewId;
	private JButton btnUpdate;
	private JScrollPane scrollPaneReview ;
	private JLabel lblUpdate;
	private DefaultTableModel model;
	private JComboBox comboBoxScore;
	private JLabel lblNewLabel;
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					FrmupdateRevivew frame = new FrmupdateRevivew();
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
	public FrmupdateRevivew() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 696, 442);
		contentPane = new JPanel() {  //pic
            /**
			 * 
			 */
			private static final long serialVersionUID = 1L;

			public void paintComponent(Graphics g) {  
                    Image img = Toolkit.getDefaultToolkit().getImage(  
                    		HomePage.class.getResource("/boundary/images/background1.png"));  //backgroundImage
                    g.drawImage(img, 0, 0, this.getWidth(), this.getHeight(), this);  
               }  
         };        
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		
		Intialize();
		
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		
		
		
		
		
	}

	private void Intialize() {
		
		comboBoxScore = new JComboBox();
		for(int i=0;i<=100;i++)
		{
			comboBoxScore.addItem(""+i);
		}
		comboBoxScore.setBounds(174, 184, 77, 22);
		contentPane.add(comboBoxScore);
		
		 lblUpdate = new JLabel("choose which to update");
		 lblUpdate.setOpaque(true);
		 lblUpdate.setBackground(new Color(255, 255, 255));
		 lblUpdate.setForeground(new Color(0, 0, 0));
		 lblUpdate.setFont(new Font("Tahoma", Font.PLAIN, 14));
		 lblUpdate.setBounds(10, 140, 147, 33);
		 contentPane.add(lblUpdate);
		 
		 lblNewLabel = new JLabel("Score");
		 lblNewLabel.setOpaque(true);
		 lblNewLabel.setBackground(new Color(255, 255, 255));
			lblNewLabel.setFont(new Font("Tahoma", Font.PLAIN, 14));
			lblNewLabel.setBounds(174, 145, 77, 22);
			contentPane.add(lblNewLabel);
			
		JLabel lblReview = new JLabel("your revivews");
		lblReview.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblReview.setBounds(24, 38, 103, 33);
		contentPane.add(lblReview);
		
		comboBoxRevivewId = new JComboBox();
		comboBoxRevivewId.setBounds(56, 184, 108, 22);
		contentPane.add(comboBoxRevivewId);
		
		 btnUpdate = new JButton("update");
		 btnUpdate.addActionListener(new ActionListener() {
		 	public void actionPerformed(ActionEvent e) {
		 		if(Login.UserId!=null)
		 		{
			 		if(comboBoxRevivewId.getSelectedItem().toString().equals("choose") || textDescribe.getText().toString().isEmpty())
			 		{
			 			JOptionPane.showMessageDialog(null, "not selected an review or not enter text", "Error", JOptionPane.ERROR_MESSAGE);
			 		}
			 		else
			 		{
			 				DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd/MM/yyyy");
			            LocalDate currentDate = LocalDate.now();
			            String formattedDate = currentDate.format(formatter);
			           Date writeDate;
					try {
						writeDate = new SimpleDateFormat("dd/MM/yyyy").parse(formattedDate);
			            // Call the method to add review to trip
						Integer score=Integer.parseInt(comboBoxScore.getSelectedItem().toString());
						Integer reviewID=Integer.parseInt(comboBoxRevivewId.getSelectedItem().toString());
			           boolean success = Revivewlogic.getInstance().editReview(reviewID, score, textDescribe.getText().toString(),writeDate);
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
		 		}
		 		else
		 			 JOptionPane.showMessageDialog(null, "how do you got here", "Error", JOptionPane.ERROR_MESSAGE);
		 	}
		 });
		btnUpdate.setFont(new Font("Tahoma", Font.PLAIN, 14));
		btnUpdate.setBounds(514, 183, 89, 23);
		contentPane.add(btnUpdate);
		
		textDescribe = new JTextField();
		textDescribe.setBounds(261, 186, 242, 20);
		contentPane.add(textDescribe);
		textDescribe.setColumns(10);
		
		scrollPaneReview = new JScrollPane();
		scrollPaneReview.setBounds(137, 30, 492, 85);
		contentPane.add(scrollPaneReview);
		
		 String[] columns = {"ReviewID", "score", "comment", "placeId", "TripNumber","timeWrite"};
	     model = new DefaultTableModel(columns, 0);
		
		tableReview = new JTable(model);
		refreshReviews();
		scrollPaneReview.setViewportView(tableReview);
		
	}
	public void refreshReviews()
	{
		String[] columns = {"ReviewID", "score", "comment", "placeId", "TripNumber","timeWrite"};
		model = new DefaultTableModel(columns, 0);
		while(model!=null && model.getRowCount()!=0)
		{
			model.removeRow(0);
		} 
		comboBoxRevivewId.removeAllItems();
	     comboBoxRevivewId.addItem("choose");
		if(Login.UserId!=null)
		{
			ArrayList<review> reviews = Revivewlogic.getInstance().UserReviews(Login.UserId);// get all places
			//System.out.println(places);
	        for (review r : reviews) {
	            Object[] row = {
	               r.getReviewID(),
	               r.getScore(),
	               r.getComment(),
	             r.getPlaceId(),
	               r.getTripNumber(),
	                r.getTimeWrite()
	            };
	            comboBoxRevivewId.addItem(r.getReviewID());
	            try {
	                // Add the row directly to the table model
	            	model.addRow(row);
	            	//System.out.println(row);
	            } catch (Exception ex) {
	                ex.printStackTrace();
	               // JOptionPane.showMessageDialog(this, "Error adding row to table: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
	            }
	        }
		}
        tableReview.setModel(model);
	}
}
