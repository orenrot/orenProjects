package boundary;

import java.awt.EventQueue;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Toolkit;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.table.DefaultTableModel;

import control.PlaceLogic;
import entity.Place;
import entity.UserRequest;

import javax.swing.JLabel;
import javax.swing.JOptionPane;

import java.awt.Font;
import javax.swing.JComboBox;
import javax.swing.DefaultComboBoxModel;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.awt.event.ActionEvent;
import javax.swing.JScrollBar;
import java.awt.ScrollPane;
import javax.swing.JScrollPane;
import javax.swing.JTable;

public class FrmPlacesOccasional extends HomePage {

	private JPanel contentPane;
	private JLabel lblSearch;
	private JComboBox comboBoxOption;
	private JComboBox comboBoxChoice;
	private JScrollPane scrollPaneData ;
	private JTable table;
	private DefaultTableModel model;
	private JTable tableData;
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					FrmPlacesOccasional frame = new FrmPlacesOccasional();
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
	public FrmPlacesOccasional() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 720, 500);
		contentPane = new JPanel() {  //pic
            /**
			 * 
			 */
			private static final long serialVersionUID = 1L;

			public void paintComponent(Graphics g) {  
                    Image img = Toolkit.getDefaultToolkit().getImage(  
                    		FrmPlacesOccasional.class.getResource("/boundary/images/background1.png"));  //backgroundImage
                    g.drawImage(img, 0, 0, this.getWidth(), this.getHeight(), this);  
               }  
         };      
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		Intiliazie();
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		
		
	   
		
		
	}

	private void Intiliazie() {
		
		lblSearch = new JLabel("search by");
		lblSearch.setFont(new Font("Tahoma", Font.PLAIN, 16));
		lblSearch.setBounds(31, 48, 96, 20);
		contentPane.add(lblSearch);
		
		comboBoxChoice = new JComboBox();
		comboBoxChoice.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				ArrayList<Place> places=new ArrayList<>();
		     //	if(comboBoxChoice==null   ||  comboBoxChoice.getSelectedItem()==null || comboBoxChoice.getSelectedItem().toString().isEmpty())
			//	{
					//nothing
			//	}
				 if(comboBoxChoice!=null  &&  comboBoxChoice.getSelectedItem()!=null &&  !comboBoxChoice.getSelectedItem().toString().isEmpty() )
				{
					String optionChoosen=(comboBoxChoice.getSelectedItem().toString());
					if(comboBoxOption!=null && comboBoxOption.getSelectedItem()!=null  && comboBoxOption.getSelectedItem().toString().equals("city name"))
					{
						  places=PlaceLogic.getInstance().getPlaceByCityName(optionChoosen);
						  String[] columnsplaces = {"Place ID", "Name of place", "description", "urlLandMark", "price level", "city of place"};//Columns of Places
					         model= new DefaultTableModel(columnsplaces, 0);
					         for(Place p:places)
					         {
					        	  Object[] row = {
							                p.getPlaceId(),
							                p.getNameOfPlace(),
							                p.getDescription(),
							                p.getUrlLandmark(),
							                p.getPriceLevel(),
							                p.getCity() };//to must of the time it will have both
						            try {
						            	model.addRow(row);
						            } catch (Exception ex) {
						                ex.printStackTrace();
						   
						            }
						        }
					         tableData.setModel(model);
					         scrollPaneData.setVisible(true);
					}
					else if(comboBoxOption!=null && comboBoxOption.getSelectedItem()!=null  && comboBoxOption.getSelectedItem().toString().equals("country name"))
					{
						places=PlaceLogic.getInstance().getPlaceByCountryName(optionChoosen);
						  String[] columnsplaces = {"Place ID", "Name of place", "description", "urlLandMark", "price level", "city of place"};//Columns of Places
					         model= new DefaultTableModel(columnsplaces, 0);
					         for(Place p:places)
					         {
					        	  Object[] row = {
							                p.getPlaceId(),
							                p.getNameOfPlace(),
							                p.getDescription(),
							                p.getUrlLandmark(),
							                p.getPriceLevel(),
							                p.getCity() };//to must of the time it will have both
						            try {
						            	model.addRow(row);
						            } catch (Exception ex) {
						                ex.printStackTrace();
						   
						            }
						        }
					         tableData.setModel(model);
					         scrollPaneData.setVisible(true);
					}
				}
			//	else
			//		 JOptionPane.showMessageDialog(null, "Please select an option to filter by", "Error", JOptionPane.ERROR_MESSAGE);
			}
		});
		comboBoxChoice.setBounds(276, 49, 121, 22);
		comboBoxChoice.setVisible(false);
		contentPane.add(comboBoxChoice);
		
		comboBoxOption = new JComboBox();
		comboBoxOption.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if(!comboBoxOption.getSelectedItem().toString().equals("choose option"))
				{
					comboBoxChoice.setVisible(true);
					if(comboBoxOption.getSelectedItem().toString().equals("country name"))
					{
						ArrayList<String> countryNames= PlaceLogic.getInstance().getCountryName();
						comboBoxChoice.removeAllItems();//delete all before
						 comboBoxChoice.setVisible(true);
						comboBoxChoice.addItem("please choose");
						for(String name:countryNames)
							comboBoxChoice.addItem(name);
					}
					else if(comboBoxOption.getSelectedItem().toString().equals("city name"))
					{
						ArrayList<String> cityNames= PlaceLogic.getInstance().getCityName();
						 comboBoxChoice.setVisible(true);
						comboBoxChoice.removeAllItems();//delete all before
						comboBoxChoice.addItem("please choose");
						for(String name:cityNames)
							comboBoxChoice.addItem(name);
					}
					else if(comboBoxOption.getSelectedItem().toString().equals("all places"))
					{
						ArrayList<Place> places=new ArrayList<>();
						places=PlaceLogic.getInstance().getPlace();
						  String[] columnsplaces = {"Place ID", "Name of place", "description", "urlLandMark", "price level", "city of place"};//Columns of Places
					         model= new DefaultTableModel(columnsplaces, 0);
					         for(Place p:places)
					         {
					        	  Object[] row = {
							                p.getPlaceId(),
							                p.getNameOfPlace(),
							                p.getDescription(),
							                p.getUrlLandmark(),
							                p.getPriceLevel(),
							                p.getCity()+""+p.getCountryNumber() };//to must of the time it will have both
						            try {
						            	model.addRow(row);
						            } catch (Exception ex) {
						                ex.printStackTrace();
						   
						            }
						        }
					         tableData.setModel(model);
					         scrollPaneData.setVisible(true);
					         comboBoxChoice.setVisible(false);
					}
				}
			}
		});
		comboBoxOption.setModel(new DefaultComboBoxModel(new String[] {"choose option", "country name", "city name", "all places"}));
		comboBoxOption.setFont(new Font("Tahoma", Font.PLAIN, 16));
		comboBoxOption.setBounds(137, 49, 129, 22);
		contentPane.add(comboBoxOption);
		
		 String[] columnsplaces = {"Place ID", "Name of place", "description", "urlLandMark", "price level", "city of place"};//Columns of Places
         model= new DefaultTableModel(columnsplaces, 0);
     /*    table = new JTable();
         table.setFont(new Font("Tahoma", Font.PLAIN, 14));
         table.setBounds(471, 380, -250, -150);
         table.setModel(model);
         table.setVisible(true);*/
         tableData = new JTable(model);
 		tableData.setBounds(137, 218, 239, 169);
 		//tableData.setVisible(false);
 		//contentPane.add(tableData);
		scrollPaneData = new JScrollPane(tableData);
		scrollPaneData.setBounds(31, 118, 578, 216);
		scrollPaneData.setVisible(false);
		contentPane.add(scrollPaneData);
		
		//contentPane.add(table);
	
		
	}
}
