package boundary;

import java.awt.EventQueue;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Toolkit;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;

import control.PlaceLogic;
import control.Revivewlogic;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class FrmVicePercidentExport extends HomePage {

	private JPanel contentPane;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					FrmVicePercidentExport frame = new FrmVicePercidentExport();
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
	public FrmVicePercidentExport() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 664, 454);
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
		
		ImageIcon icon = new ImageIcon(getClass().getResource("/boundary/images/xmlImage.png"));


		JButton btnNewButton = new JButton("export & import to xml");
		btnNewButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				PlaceLogic.getInstance().exportPlacesToXML3();//need to move to vp and like this
				PlaceLogic.getInstance().importPlacesFromXML2("xml/place3.xml");//WORKING import from place 3
				//PlaceLogic.getInstance().importPlacesFromXML("xml/place3.xml","xml/distance2.xml");//need to move to vp and like this
			}
		});
		btnNewButton.setIcon(icon);
		btnNewButton.setBounds(176, 136, 218, 29);
		contentPane.add(btnNewButton);
		 icon = new ImageIcon(getClass().getResource("/boundary/images/jsonImage.png"));

		JButton btnJsomn = new JButton("review to Json ");
		btnJsomn.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				Revivewlogic.getInstance().exportReviewsToJSON();
			}
		});
		btnJsomn.setIcon(icon);
		btnJsomn.setBounds(176, 204, 218, 29);
		contentPane.add(btnJsomn);
	}

}
