package boundary;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;

import control.TripLogic;

import javax.swing.JLabel;
import javax.swing.JOptionPane;

import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Toolkit;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashSet;
import java.util.Random;
import javax.swing.JFormattedTextField;
import com.toedter.calendar.JDateChooser;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.awt.event.ActionEvent;
import javax.swing.JScrollPane;
import java.awt.Component;

public class FrmCreateTrip extends HomePage {

	private JPanel contentPane;
	private JLabel lblTripNumber;
	public static Integer TripId;
	public static Integer MoveToAllInfo=-1;
	private Random rnd;
	private HashSet<Integer> tripsId;
	private JDateChooser dateStart;
	private Date startDate;
	private Date endDate;
	private JDateChooser dateEnd;
	private JLabel lblStartDate;
	private JLabel lblEndDate;
	private JButton btnCreate;
	private Integer randomSixDigitNumber;
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					FrmCreateTrip frame = new FrmCreateTrip();
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
	public FrmCreateTrip() {
		tripsId= new HashSet<Integer>();
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 723, 541);
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
		
		setContentPane(contentPane);
		contentPane.setLayout(null);
		tripsId.addAll(TripLogic.getInstance().GetTripNumbers());
		rnd= new Random();
		Integer min = 100000; // 6-digit number starts from 100,000
		Integer max = 999999; // 6-digit number ends at 999,999
		 randomSixDigitNumber = rnd.nextInt(max - min + 1) + min;
		if(tripsId.contains(randomSixDigitNumber))
		{
			while(tripsId.contains(randomSixDigitNumber))
				randomSixDigitNumber = rnd.nextInt(max - min + 1) + min;// 6 digits
		}

		lblTripNumber = new JLabel("Your Trip Id is:  "+randomSixDigitNumber);
		lblTripNumber.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblTripNumber.setBounds(10, 34, 236, 38);
		contentPane.add(lblTripNumber);
		
		 lblStartDate  = new JLabel("Start Date");
		 lblStartDate.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblStartDate.setBounds(20, 83, 70, 26);
		contentPane.add(lblStartDate);
		
		 lblEndDate = new JLabel("End Date");
		 lblEndDate.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblEndDate.setBounds(20, 132, 70, 26);
		contentPane.add(lblEndDate);
		
		dateStart = new JDateChooser();
		dateStart.getCalendarButton().setFont(new Font("Tahoma", Font.PLAIN, 14));
		dateStart.setBounds(100, 83, 111, 20);
		contentPane.add(dateStart);
		
		 dateEnd = new JDateChooser();
		 dateEnd.getCalendarButton().setFont(new Font("Tahoma", Font.PLAIN, 14));
		dateEnd.setBounds(100, 132, 111, 20);
		contentPane.add(dateEnd);
		
		btnCreate = new JButton("create");
		btnCreate.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				FrmCreateTrip.TripId=randomSixDigitNumber;
				endDate=dateEnd.getDate();
				startDate=dateStart.getDate();
				 SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy");
		            String selectedDateString = sdf.format(startDate);
		            System.out.println(selectedDateString);
		            try {
						startDate=new SimpleDateFormat("dd/MM/yyyy").parse(selectedDateString);
					} catch (ParseException e1) {
						// TODO Auto-generated catch block
						e1.printStackTrace();
					}
		            System.out.println(selectedDateString);
		             sdf = new SimpleDateFormat("dd/MM/yyyy");
		             selectedDateString = sdf.format(endDate);
		            try {
		            	endDate=new SimpleDateFormat("dd/MM/yyyy").parse(selectedDateString);
					} catch (ParseException e1) {
						// TODO Auto-generated catch block
						e1.printStackTrace();
					}
		           // System.out.println(startDate);
				if(startDate.after(endDate))
				{
					JOptionPane.showMessageDialog(null, "the date start is after the end date", "Error", JOptionPane.ERROR_MESSAGE);
				}
				else
				{
					System.out.println(startDate+" and end="+endDate);
					boolean success=TripLogic.getInstance().addTrip(TripId, startDate, endDate,Login.UserId,0);
					if(success)	
					{
						MoveToAllInfo=0;
						JOptionPane.showMessageDialog(null, "success", "good", JOptionPane.PLAIN_MESSAGE);
						new TripCorrector4().setVisible(true);
						dispose();
					}
					else
						JOptionPane.showMessageDialog(null, "error", "Error", JOptionPane.ERROR_MESSAGE);
				}
			}
		});
		btnCreate.setFont(new Font("Tahoma", Font.PLAIN, 14));
		btnCreate.setBounds(122, 172, 89, 23);
		contentPane.add(btnCreate);
	}
}
