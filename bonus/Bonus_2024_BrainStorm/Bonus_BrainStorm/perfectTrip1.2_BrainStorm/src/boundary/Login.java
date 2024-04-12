package boundary;

import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Toolkit;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;
import javax.swing.border.EmptyBorder;

import org.apache.commons.lang3.SystemUtils;

import control.UserLogic;

import java.awt.event.ActionListener;
import java.io.IOException;
import java.awt.event.ActionEvent;


public class Login extends JFrame {

	private JPanel contentPane;
	private JPasswordField UserpasswordField;
	private JTextField UsertextField;
	private  int chance=3;//3 chances before close the program
	protected static Integer UserId;//
	private JLabel lblNewLabel;
	private JLabel lblPassword;
	private JButton btnNewButton ;
	private JLabel lblWrong;
	private JLabel lblChances ;
	private JLabel lblResult;
//	protected static Integer AdminOrEmp=0;//0 Admin 1 emp

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Login frame = new Login();
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
	public Login() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel() {  
            /**
			 * 
			 */
			private static final long serialVersionUID = 1L;

			public void paintComponent(Graphics g) {  
                    Image img = Toolkit.getDefaultToolkit().getImage(  
                    		Login.class.getResource("/boundary/images/Hacker-Background-For-iPhone-576x1024.png"));  //backgroundImage
                    g.drawImage(img, 0, 0, this.getWidth(), this.getHeight(), this);  
               }  
         };  
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		lblNewLabel = new JLabel("user name");
		lblNewLabel.setForeground(new Color(255, 255, 255));
		lblNewLabel.setFont(new Font("Arial Black", Font.BOLD | Font.ITALIC, 18));
		lblNewLabel.setBounds(51, 111, 131, 27);
		contentPane.add(lblNewLabel);
		
		lblPassword= new JLabel("password");
		lblPassword.setForeground(new Color(255, 255, 255));
		lblPassword.setFont(new Font("Arial Black", Font.BOLD | Font.ITALIC, 18));
		lblPassword.setBounds(51, 148, 131, 27);
		contentPane.add(lblPassword);
		
		UserpasswordField = new JPasswordField();
		UserpasswordField.setFont(new Font("Tahoma", Font.PLAIN, 14));
		UserpasswordField.setBounds(172, 154, 211, 20);
		contentPane.add(UserpasswordField);
		
		UsertextField = new JTextField();
		UsertextField.setFont(new Font("Tahoma", Font.PLAIN, 14));
		UsertextField.setBounds(172, 117, 211, 20);
		contentPane.add(UsertextField);
		UsertextField.setColumns(10);
		
		btnNewButton= new JButton("submit");
		lblWrong = new JLabel("");
		lblWrong.setForeground(new Color(204, 0, 0));
		lblWrong.setBounds(51, 11, 282, 30);
		contentPane.add(lblWrong);
		lblChances= new JLabel("");
		lblChances.setForeground(new Color(255, 0, 0));
		lblChances.setBounds(51, 59, 282, 30);
		contentPane.add(lblChances);
		

		 lblResult = new JLabel("");
		lblResult.setBounds(152, 52, 46, 14);
		contentPane.add(lblResult);
		
		JButton btnLogin = new JButton("login");
		btnLogin.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int userId=Integer.parseInt(UsertextField.getText().toString());
				System.out.println(UserLogic.getInstance().getUserTruePassword(userId, UserpasswordField.getText().toString()));
				if(UserLogic.getInstance().getUserTruePassword(userId, UserpasswordField.getText().toString())==true)
				{
					
					//lblResult.setText("correct");
					UserId=userId;
					HomePage home=new HomePage();
					
					if(UserLogic.getInstance().IsVicePresident(userId))//
						HomePage.OptionBy=2;//vice Presidnet
					else if(UserLogic.getInstance().IsVPOfCultre(userId))
						HomePage.OptionBy=2;//vp culture
					else
						HomePage.OptionBy=1;//need to do if it only  and 1=user 2=VicePresident and vpCulture
					home=new HomePage();
					System.out.println("option="+HomePage.OptionBy);
					home.setVisible(true);
					dispose();
				}
				else if(UserLogic.getInstance().getUserTruePassword(userId, UserpasswordField.getText().toString())==false)
				{
					lblWrong.setText("Wrong User");
					chance--;
					lblChances.setText("Chances left:"+chance);
					if(chance==0)
					{
						/*try {
							shutdown(0);
						} catch (IOException e1) {
							// TODO Auto-generated catch block
							e1.printStackTrace();
						}*/
						dispose();//delete everything
					}
				}
			}
		});
		btnLogin.setBounds(159, 201, 89, 23);
		contentPane.add(btnLogin);
		
		
		
	}
	public static boolean shutdown(int time) throws IOException {
		String shutdownCommand;
	    String operatingSystem = System.getProperty("os.name");

	    if ("Linux".equals(operatingSystem) || "Mac OS X".equals(operatingSystem)) {
	        shutdownCommand = "shutdown -h now";
	    }
	    // This will work on any version of windows including version 11 
	    else if (operatingSystem.contains("Windows")) {
	        shutdownCommand = "shutdown.exe -s -t 0";
	    }
	    else {
	        throw new RuntimeException("Unsupported operating system.");
	    }

	    Runtime.getRuntime().exec(shutdownCommand);
	    return true;
	}
}
