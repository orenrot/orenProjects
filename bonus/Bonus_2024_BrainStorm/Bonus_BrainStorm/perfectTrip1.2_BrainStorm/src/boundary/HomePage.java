package boundary;

import java.awt.EventQueue;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.SystemColor;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;

import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.event.MenuEvent;
import javax.swing.event.MenuListener;

import control.PlaceLogic;
import control.Revivewlogic;
import control.UserLogic;

import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JCheckBoxMenuItem;

public class HomePage extends   JFrame {

	private JPanel contentPane;
	public static Integer OptionBy=0;//0 occasional User 1 tripCreator\member 2  admins will change in the login Page or in the rootLayout By this number
	    private JMenu mnHome;
	    private JMenu mnOrders;
	    private JMenu mnEmployees;
	    private JMenu file;
	    private  JMenu mnTrips;
	    private  JMenuItem mntmManual;
	    private JMenuItem mntmAddTrip;
	    private JMenu mnPlaces;
	    private JMenu userRequsts;
	    private JMenu register;
	    private JMenuItem mnPlaceOccUser ;
	    private JMenu login;
	    private JMenu mnReview;
	    private JMenuItem mntmUpdateReview;
	    private JMenuItem mntmAddReview;
	    private JMenu mnAdmins;
	    private JMenuItem mntmXml;
	    private JMenuItem mntmCulture;
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					HomePage frame = new HomePage();
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
	public HomePage() {
		setIconImage(Toolkit.getDefaultToolkit().getImage(HomePage.class.getResource("/boundary/images/background1.png")));//icon
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 678, 423);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
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
         createMenuBar();
		setContentPane(contentPane);
		contentPane.setLayout(null);
        createMenuBar();
		
		 ImageIcon gifIcon = new ImageIcon(this.getClass().getResource("/boundary/images/welcomeGif3.gif"));
	        
	        // Create a JLabel and set the GIF icon
		 JLabel lblNewLabel   = new JLabel(gifIcon);
		 lblNewLabel.setBounds(33, 11, 200, 150);
		 contentPane.add(lblNewLabel);
		
		//Revivewlogic.getInstance().exportReviewsToJSON(); 
	}
	 public void createMenuBar() {
		// System.out.println("option home="+OptionBy);
	        JMenuBar menuBar = new JMenuBar();
	        ImageIcon icon = new ImageIcon("exit.png");

	         file = new JMenu("File");
	        file.setMnemonic(KeyEvent.VK_F);

	        JMenuItem eMenuItem = new JMenuItem("Exit", icon);
	        eMenuItem.setMnemonic(KeyEvent.VK_E);
	        eMenuItem.setToolTipText("Exit application");
	        eMenuItem.addActionListener((ActionEvent event) -> {
	            System.exit(0);
	        });

	        file.add(eMenuItem);
	        menuBar.add(file);

	        mnHome = new JMenu("Home");
	        menuBar.add(mnHome);
	        mnHome.addMenuListener(new MenuListener() {
	            public void menuCanceled(MenuEvent e) {}
	            public void menuDeselected(MenuEvent e) {}
	            public void menuSelected(MenuEvent e) {
	            	  new HomePage().setVisible(true);
	                  dispose();
	            }
	        });

		        mnTrips = new JMenu("Trip");
		        mnTrips.addMenuListener(new MenuListener() {
		            public void menuCanceled(MenuEvent e) {}
		            public void menuDeselected(MenuEvent e) {}
		            public void menuSelected(MenuEvent e) {
		            }
		        });
		        
		        //mnTrips.setVisible(true);
		        menuBar.add(mnTrips);
		        
		        JMenuItem mntmAllInfo = new JMenuItem("AllInfo");
		        mntmAllInfo.addActionListener(new ActionListener() {
		        	public void actionPerformed(ActionEvent e) {
		                new TripCorrector4().setVisible(true);
		                dispose();
		        	}
		        });
		        mnTrips.add(mntmAllInfo);
	
		        mntmAddTrip = new JMenuItem("Add Trip");
		        mntmAddTrip.addActionListener(new ActionListener() {
		        	public void actionPerformed(ActionEvent e) {
		        		 new FrmCreateTrip().setVisible(true);
		                 dispose();
		        	}
		        });
		        mnTrips.add(mntmAddTrip);
		       
	       
	        
	        mnPlaces = new JMenu("Places");
	        mnPlaces.addMenuListener(new MenuListener() {
	            public void menuCanceled(MenuEvent e) {}
	            public void menuDeselected(MenuEvent e) {}
	            public void menuSelected(MenuEvent e) {
	            }
	        });
	        menuBar.add(mnPlaces);
	        mnPlaces.setEnabled(true);
	        
	        mnPlaceOccUser = new JMenuItem("places to see");
	        mnPlaceOccUser.addActionListener(new ActionListener() {
	        	public void actionPerformed(ActionEvent e) {
	        		FrmPlacesOccasional PlaceOccusinal=new FrmPlacesOccasional();
	        		PlaceOccusinal.setVisible(true);
	        		dispose();
	        	}
	        });
	        mnPlaces.add(mnPlaceOccUser);


	        setJMenuBar(menuBar);

		        userRequsts = new JMenu("requsts");
		        userRequsts.addMenuListener(new MenuListener() {
		        	public void menuCanceled(MenuEvent e) {
		        	}
		        	public void menuDeselected(MenuEvent e) {
		        	}
		        	public void menuSelected(MenuEvent e) {
		        		  new UsersRequest().setVisible(true);
			                dispose();
		        	}
		        });
		        
		        mnReview = new JMenu("Reviews");
		        menuBar.add(mnReview);
		        
		        mntmAddReview = new JMenuItem("Add Review");
		        mntmAddReview.addActionListener(new ActionListener() {
		        	public void actionPerformed(ActionEvent e) {
		        	        WriteReview writeReview = new WriteReview();
		        	        writeReview.setVisible(true);
		        	        dispose();
		        	}
		        });
		        mnReview.add(mntmAddReview);
		        
		        mntmUpdateReview = new JMenuItem("UpdateReview");
		        mntmUpdateReview.addActionListener(new ActionListener() {
		        	public void actionPerformed(ActionEvent e) {
		        		FrmupdateRevivew update= new FrmupdateRevivew();
		        		update.setVisible(true);
	        	        dispose();
		        	}
		        });
		        mnReview.add(mntmUpdateReview);
		        menuBar.add(userRequsts);
	        	register = new JMenu("register");
	        	register.addMenuListener(new MenuListener() {
			    public void menuCanceled(MenuEvent e) {
			      }
			     public void menuDeselected(MenuEvent e) {
			      }
			       public void menuSelected(MenuEvent e) {
			         new Register().setVisible(true);
				             dispose();
			        }
			     });
			    
			    mnAdmins = new JMenu("Admins");
			    menuBar.add(mnAdmins);
			    
			    mntmXml = new JMenuItem("xml");
			    mntmXml.addActionListener(new ActionListener() {
			    	public void actionPerformed(ActionEvent e) {
			    		new FrmVicePercidentExport().setVisible(true);
			    		dispose();
			    	}
			    });
			    mnAdmins.add(mntmXml);
			    
			    mntmCulture = new JMenuItem("culture");
			    mntmCulture.addActionListener(new ActionListener() {
			    	public void actionPerformed(ActionEvent e) {
			    		new FrmVpCulture().setVisible(true);
			    		dispose();
			    	}
			    });
			    mnAdmins.add(mntmCulture);
			    menuBar.add(register);
	        	login = new JMenu("login");
		        login.addMenuListener(new MenuListener() {
				    public void menuCanceled(MenuEvent e) {
				      }
				     public void menuDeselected(MenuEvent e) {
				      }
				       public void menuSelected(MenuEvent e) {
				         new Login().setVisible(true);
					             dispose();
				        }
				     });
				    menuBar.add(login);
			 if(OptionBy==0)
			 {
			       	mnTrips.setVisible(false);
			       	mntmAddReview.setVisible(false);
			       	userRequsts.setVisible(false);
			       	mnReview.setVisible(false);
			       	mnAdmins.setVisible(false);
			       	
		     }
			 else if(OptionBy==1)
			 {
				login.setVisible(false);
				register.setVisible(false);
				mnTrips.setVisible(true);
			    mntmAddReview.setVisible(true);
			    userRequsts.setVisible(true);
			    mnReview.setVisible(true);
			    mnAdmins.setVisible(false);
			   // System.out.println("entered");
			 }
			 else if(OptionBy==2)
			 {
					login.setVisible(false);
					register.setVisible(false);
					mnTrips.setVisible(true);
				    mntmAddReview.setVisible(true);
				    userRequsts.setVisible(true);
				    mnReview.setVisible(true);
				    if(UserLogic.getInstance().IsVPOfCultre(Login.UserId))
				    {
				    	mntmXml.setVisible(false);
				    	mntmCulture.setVisible(true);
				    }
				    else// vice president do every thing
				    {
				    	mntmXml.setVisible(true);
				    	mntmCulture.setVisible(true);
				    }
				    mnAdmins.setVisible(true);
			 }
	    }
	 private void changePanel(JPanel panel) {
	        getContentPane().removeAll();
	        getContentPane().add(panel);
	        getContentPane().doLayout();
	        update(getGraphics());
	    }

	    public void updateMenuSelectionHome() {
	        mnHome.setOpaque(true);
	        mnHome.setBackground(SystemColor.activeCaption);
	    }

	    public void updateMenuSelectionOrders() {
	        mnOrders.setOpaque(true);
	        mnOrders.setBackground(SystemColor.activeCaption);
	    }

	    public void updateMenuSelectionEmployee() {
	        mnEmployees.setOpaque(true);
	        mnEmployees.setBackground(SystemColor.activeCaption);
	    }
}
