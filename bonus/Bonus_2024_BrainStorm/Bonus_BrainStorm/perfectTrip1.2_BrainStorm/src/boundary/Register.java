package boundary;
import java.awt.EventQueue;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Toolkit;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;

import control.UserLogic;
import entity.User;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JTextField;
import java.awt.event.ActionListener;
import java.util.Properties;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.awt.event.ActionEvent;
import javax.swing.JPasswordField;

public class Register extends HomePage {

	private JPanel contentPane;
	private JTextField txtFirstName;
	private JTextField txtLastName;
	private JTextField txtEmail;
	private JButton btnRegister;
	private JLabel lblFirstName;
	private JLabel lblLastName;
	private JLabel lblEmail;
	private JPasswordField passwordField;
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Register frame = new Register();
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
	public Register() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 554, 397);
		contentPane = new JPanel() {  //pic
            /**
			 * 
			 */
			private static final long serialVersionUID = 1L;

			public void paintComponent(Graphics g) {  
                    Image img = Toolkit.getDefaultToolkit().getImage(  
                    		Register.class.getResource("/boundary/images/background1.png"));  //backgroundImage
                    g.drawImage(img, 0, 0, this.getWidth(), this.getHeight(), this);  
               }  
         };    
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		   
		setContentPane(contentPane);
		contentPane.setLayout(null);
		

		
		 lblFirstName = new JLabel("FirstName");
		lblFirstName.setBounds(10, 43, 70, 14);
		contentPane.add(lblFirstName);
		
		txtFirstName = new JTextField();
		txtFirstName.setBounds(90, 40, 86, 20);
		contentPane.add(txtFirstName);
		txtFirstName.setColumns(10);
		
		 lblLastName = new JLabel("LastName");
		lblLastName.setBounds(10, 74, 70, 14);
		contentPane.add(lblLastName);
		
		txtLastName = new JTextField();
		txtLastName.setColumns(10);
		txtLastName.setBounds(90, 71, 86, 20);
		contentPane.add(txtLastName);
		
		 lblEmail = new JLabel("Email");
		lblEmail.setBounds(10, 113, 70, 14);
		contentPane.add(lblEmail);
		
		txtEmail = new JTextField();
		txtEmail.setColumns(10);
		txtEmail.setBounds(90, 110, 86, 20);
		contentPane.add(txtEmail);
		
		JLabel lblPassWord = new JLabel("Password");
		lblPassWord.setBounds(10, 160, 46, 14);
		contentPane.add(lblPassWord);
		
		passwordField = new JPasswordField();
		passwordField.setBounds(90, 157, 86, 20);
		
		 btnRegister = new JButton("Register");
		 btnRegister.addActionListener(new ActionListener() {
		 	public void actionPerformed(ActionEvent e) {
		 		if(txtEmail.getText().toString().isEmpty())
		 		{
		 			JOptionPane.showMessageDialog(null, "enter email the field is empty", "user register",JOptionPane.PLAIN_MESSAGE);
		 		}
		 		else
		 		{
		 			if(UserLogic.getInstance().getEmail(txtEmail.getText().toString()))
		 			{
		 				JOptionPane.showMessageDialog(null, "enter new email", "email found",JOptionPane.PLAIN_MESSAGE);
		 			}
		 			else if(txtLastName.getText().toString().isEmpty() || txtFirstName.getText().toString().isEmpty() || passwordField.getText().toString().isEmpty())
		 			{
		 				JOptionPane.showMessageDialog(null, "one of the fields is empty", "user register",JOptionPane.PLAIN_MESSAGE);
		 			}
		 			else
		 			{
		 				Integer userId=UserLogic.getInstance().getLastId();
		 				String first=txtFirstName.getText().toString();
		 				String last=txtLastName.getText().toString();
		 				String email=txtEmail.getText().toString();
		 				String pass=passwordField.getText().toString();
		 			   String EMAIL_PATTERN ="^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";
		 			   Pattern pattern = Pattern.compile(EMAIL_PATTERN);
		 				 Matcher matcher = pattern.matcher(email);
		 				 if( !matcher.matches())
		 				  {
			 					JOptionPane.showMessageDialog(null, "email is not good", "error email",JOptionPane.ERROR_MESSAGE);
			 					return;
		 				   }
		 				User newUser = new User(userId,first,last,email,pass);
		 				System.out.println(newUser);
		 				boolean success=UserLogic.getInstance().InsertUser(newUser);
		 				if(success)
		 				{
		 					JOptionPane.showMessageDialog(null, "Your userName is:"+userId, "email good",JOptionPane.PLAIN_MESSAGE);
		 				}
		 				else
		 				{
		 					JOptionPane.showMessageDialog(null, "error has eccour", "error",JOptionPane.ERROR_MESSAGE);
		 				}
		 				 new HomePage().setVisible(true);//return to homepage
		                  dispose();
		 			}
		 				
		 		}
		 				
		 	}
		 });
		btnRegister.setBounds(179, 253, 89, 23);
		contentPane.add(btnRegister);
		
		
		contentPane.add(passwordField);
	}
}
