package boundary;

import java.awt.EventQueue;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Toolkit;
import java.util.ArrayList;

import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.table.DefaultTableModel;

import control.ResturantLogic;
import control.TripLogic;
import entity.Place;
import entity.Resturant;

import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import javax.swing.ListSelectionModel;

public class FrmVpCulture extends HomePage {

	private JPanel contentPane;
	private JTable tableStyles;
	private JScrollPane scrollPaneResturants;
	private JTable tableResturant;
	private DefaultTableModel modelStyle;
	private DefaultTableModel modelResturant;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					FrmVpCulture frame = new FrmVpCulture();
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
	public FrmVpCulture() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 659, 486);
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
		String[] colStyle= {"style"};
		String[] colResturant= {"Place ID", "kitchenStyle"};;
		JScrollPane scrollPaneStyle = new JScrollPane();
		scrollPaneStyle.setBounds(10, 32, 107, 124);
		contentPane.add(scrollPaneStyle);
		
		modelStyle=new DefaultTableModel(colStyle,0);
		tableStyles = new JTable(modelStyle);
		tableStyles.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
		scrollPaneStyle.setViewportView(tableStyles);
		refreshStyle();
		scrollPaneResturants = new JScrollPane();
		scrollPaneResturants.setBounds(148, 32, 282, 124);
		contentPane.add(scrollPaneResturants);
		
		modelResturant= new DefaultTableModel(colResturant,0); 
		tableResturant = new JTable(modelResturant);
		tableResturant.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
		scrollPaneResturants.setViewportView(tableResturant);
		refreshResturant();
		JButton btnNewButton = new JButton("update Resturant");
		btnNewButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				//Integer.parseInt(tableTripAddPlaceUser.getValueAt(tableTripAddPlaceUser.getSelectedRow(), 0).toString());
				if(tableStyles.getSelectedRow()==-1 || tableResturant.getSelectedRow()==-1 )
				{
					JOptionPane.showMessageDialog(null, "not selected an row of place or style", "Error", JOptionPane.ERROR_MESSAGE);
				}
				else
				{
					Integer ResturatId=Integer.parseInt(tableResturant.getValueAt(tableResturant.getSelectedRow(), 0).toString());
					String sty=tableStyles.getValueAt(tableStyles.getSelectedRow(), 0).toString();
					if(ResturantLogic.getInstance().editResturantStyle(ResturatId, sty))
					{
						JOptionPane.showMessageDialog(null, "done", "message", JOptionPane.PLAIN_MESSAGE);
						refreshResturant();
					}
					else
						JOptionPane.showMessageDialog(null, "error hapened", "Error", JOptionPane.ERROR_MESSAGE);
				}
					//editResturantStyle
			}
		});
		btnNewButton.setBounds(187, 182, 179, 23);
		contentPane.add(btnNewButton);
		
	}
	private void refreshResturant() {
		String[] colResturant= {"Place ID", "Price Level", "Name", "Description", "City", "URLmark","Rating", "kitchStyle"};;
		while(modelResturant.getRowCount()!=0)
		{
			modelResturant.removeRow(0);
		}
		
		//modelResturant.addRow(colResturant);
		ArrayList<Resturant> resturants = ResturantLogic.getInstance().getResturant();// get all places
        for (Resturant rs : resturants) {
              Object[] row = {
            		  		rs.getPlaceId(),
      	            		rs.getKitchenStyles()
                              // Add more columns if needed
                   };
            try {
            	//System.out.println(rs);
                // Add the row directly to the table model
            	modelResturant.addRow(row);
            } catch (Exception ex) {
                ex.printStackTrace();
               // JOptionPane.showMessageDialog(this, "Error adding row to table: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
            }
        }
        tableResturant.setModel(modelResturant);
	}

	public void refreshStyle( )
	{
		String[] columns = {"style"};
		while(modelStyle.getRowCount()!=0)
		{
			modelStyle.removeRow(0);
		}
		
		//modelStyle.addRow(columns);
		ArrayList<String> style = ResturantLogic.getInstance().getStyles();// get all places
        for (String sty : style) {
            Object[] row = {
               sty
            };
            try {
                // Add the row directly to the table model
            	modelStyle.addRow(row);
            } catch (Exception ex) {
                ex.printStackTrace();
               // JOptionPane.showMessageDialog(this, "Error adding row to table: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
            }
        }
        tableStyles.setModel(modelStyle);
	}
}
