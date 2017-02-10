using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using System.Security.Cryptography;
// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class IAP : MonoBehaviour, IStoreListener
{
	private static IStoreController m_StoreController; // Reference to the Purchasing system.
	private static IExtensionProvider m_StoreExtensionProvider; // Reference to store-specific Purchasing


	private static string kProductIDConsumable1 ="sun50";
	private static string kProductIDConsumable2 ="sun100";
	private static string kProductIDConsumable3 ="sun500";
	private static string kProductIDConsumable4 ="sun1000";
	private static string kProductIDConsumable5 ="sun2000";
	private static string kProductIDConsumable6 ="sun5000";


	private static string kProductNameAppleConsumable1 =    "sun50"; 
	private static string kProductNameAppleConsumable2 =    "sun100";      
	private static string kProductNameAppleConsumable3 =    "sun500";      
	private static string kProductNameAppleConsumable4 =    "sun1000";      
	private static string kProductNameAppleConsumable5 =    "sun2000";      
	private static string kProductNameAppleConsumable6 =    "sun5000";      


	private static string kProductNameGooglePlayConsumable1 =    "sun50";   
	private static string kProductNameGooglePlayConsumable2 =    "sun100"; 
	private static string kProductNameGooglePlayConsumable3 =    "sun500";  
	private static string kProductNameGooglePlayConsumable4 =    "sun1000";   
	private static string kProductNameGooglePlayConsumable5 =    "sun2000"; 
	private static string kProductNameGooglePlayConsumable6 =    "sun5000";   

	public GameObject gemsPanel, purchasePanel, purchaseSuccess, purchaseFailed;
	public Text gemInformation,failInformation;
	private int selection;
	public MainMenu main;
	public LevelMenu levelmenu;
	void Start()
	{
		
		// If we haven't set up the Unity Purchasing reference
		if (m_StoreController == null)
		{
			// Begin to configure our connection to Purchasing
			InitializePurchasing();
		}
	}

	public void ShowPurchasePanel(int id){
		purchasePanel.SetActive (true);
		switch (id) {
		case 1:
			gemInformation.text = "Are you sure you want to purchase 50 flowers for £0.99?";
			selection = 1;
			break;
		case 2:
			gemInformation.text = "Are you sure you want to purchase 100 flowers for £1.69?";
			selection = 2;
			break;
		case 3:
			gemInformation.text = "Are you sure you want to purchase 500 flowers for £4.99?";
			selection = 3;
			break;
		case 4:
			gemInformation.text = "Are you sure you want to purchase 1000 flowers for £8.99?";
			selection = 4;
			break;
		case 5:
			gemInformation.text = "Are you sure you want to purchase 2000 flowers for £14.99?";
			selection = 5;
			break;
		case 6:
			gemInformation.text = "Are you sure you want to purchase 5000 flowers for £29.99?";
			selection = 6;
			break;
		}
	}
	public void InitializePurchasing()
	{
		// If we have already connected to Purchasing ...
		if (IsInitialized())
		{
			// ... we are done here.
			return;
		}

		// Create a builder, first passing in a suite of Unity provided stores.
		var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

		// Add a product to sell / restore by way of its identifier, associating the general identifier with its store-specific identifiers.

		builder.AddProduct(kProductIDConsumable1, ProductType.Consumable, new IDs(){{ kProductNameAppleConsumable1,AppleAppStore.Name },{ kProductNameGooglePlayConsumable1,  GooglePlay.Name },});// Continue adding the non-consumable product.
		builder.AddProduct(kProductIDConsumable2, ProductType.Consumable, new IDs(){{ kProductNameAppleConsumable2,       AppleAppStore.Name },{ kProductNameGooglePlayConsumable2,  GooglePlay.Name },});// Continue adding the non-consumable product.
		builder.AddProduct(kProductIDConsumable3, ProductType.Consumable, new IDs(){{ kProductNameAppleConsumable3,       AppleAppStore.Name },{ kProductNameGooglePlayConsumable3,  GooglePlay.Name },});// Continue adding the non-consumable product.
		builder.AddProduct(kProductIDConsumable4, ProductType.Consumable, new IDs(){{ kProductNameAppleConsumable4,       AppleAppStore.Name },{ kProductNameGooglePlayConsumable4,  GooglePlay.Name },});// Continue adding the non-consumable product.
		builder.AddProduct(kProductIDConsumable5, ProductType.Consumable, new IDs(){{ kProductNameAppleConsumable5,       AppleAppStore.Name },{ kProductNameGooglePlayConsumable5,  GooglePlay.Name },});// Continue adding the non-consumable product.
		builder.AddProduct(kProductIDConsumable6, ProductType.Consumable, new IDs(){{ kProductNameAppleConsumable6,       AppleAppStore.Name },{ kProductNameGooglePlayConsumable6,  GooglePlay.Name },});// Continue adding the non-consumable product.
		UnityPurchasing.Initialize(this, builder);
	}


	private bool IsInitialized()
	{
		// Only say we are initialized if both the Purchasing references are set.
		return m_StoreController != null && m_StoreExtensionProvider != null;
	}

	public void BuyConsumable()
	{
		// Buy the non-consumable product using its general identifier. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
		switch(selection){
		case 1:
			BuyProductID (kProductIDConsumable1);
			break;
		case 2:
			BuyProductID (kProductIDConsumable2);
			break;
		case 3:
			BuyProductID (kProductIDConsumable3);
			break;
		case 4:
			BuyProductID (kProductIDConsumable4);
			break;
		case 5:
			BuyProductID (kProductIDConsumable5);
			break;
		case 6:
			BuyProductID (kProductIDConsumable6);
			break;
		}
		purchasePanel.SetActive (false);
	}


	void BuyProductID(string productId)
	{
		// If the stores throw an unexpected exception, use try..catch to protect my logic here.
		try
		{
			// If Purchasing has been initialized ...
			if (IsInitialized())
			{
				// ... look up the Product reference with the general product identifier and the Purchasing system's products collection.
				Product product = m_StoreController.products.WithID(productId);

				// If the look up found a product for this device's store and that product is ready to be sold ...
				if (product != null && product.availableToPurchase)
				{
					Debug.Log (string.Format("Purchasing product asychronously: '{0}'", product.definition.id));// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
					m_StoreController.InitiatePurchase(product);
				}
				// Otherwise ...
				else
				{
					// ... report the product look-up failure situation
				
					Debug.Log ("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
				
				}
			}
			// Otherwise ...
			else
			{
				// ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or retrying initiailization.
				Debug.Log("BuyProductID FAIL. Not initialized.");

			}
		}
		// Complete the unexpected exception handling ...
		catch (Exception e)
		{
			// ... by reporting any unexpected exception for later diagnosis.
			Debug.Log ("BuyProductID: FAIL. Exception during purchase. " + e);

		}
	}


	// Restore purchases previously made by this customer. Some platforms automatically restore purchases. Apple currently requires explicit purchase restoration for IAP.
	public void RestorePurchases()
	{
		// If Purchasing has not yet been set up ...
		if (!IsInitialized())
		{
			// ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
			Debug.Log("RestorePurchases FAIL. Not initialized.");
			return;
		}

		// If we are running on an Apple device ...
		if (Application.platform == RuntimePlatform.IPhonePlayer ||
			Application.platform == RuntimePlatform.OSXPlayer)
		{
			// ... begin restoring purchases
			Debug.Log("RestorePurchases started ...");

			// Fetch the Apple store-specific subsystem.
			var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
			// Begin the asynchronous process of restoring purchases. Expect a confirmation response in the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
			apple.RestoreTransactions((result) => {
				// The first phase of restoration. If no more responses are received on ProcessPurchase then no purchases are available to be restored.
				Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
			});
		}
		// Otherwise ...
		else
		{
			// We are not running on an Apple device. No work is necessary to restore purchases.
			Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
		}
	}


	//
	// --- IStoreListener
	//

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		// Purchasing has succeeded initializing. Collect our Purchasing references.
		Debug.Log("OnInitialized: PASS");

		// Overall Purchasing system, configured with products for this application.
		m_StoreController = controller;
		// Store specific subsystem, for accessing device-specific store features.
		m_StoreExtensionProvider = extensions;
	}


	public void OnInitializeFailed(InitializationFailureReason error)
	{
		// Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
		purchaseFailed.SetActive (true);
		failInformation.text = "Initialization failed: " + error.ToString ();

	}


	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
	{
		// A consumable product has been purchased by this user.
		if (String.Equals(args.purchasedProduct.definition.id, kProductIDConsumable1, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			//If the item has been successfully purchased, store the item for later use!
			int totalgems=ZPlayerPrefs.GetInt("totalgems");
			totalgems += 50;
			ZPlayerPrefs.SetInt("totalgems", totalgems);
			ZPlayerPrefs.Save ();
			purchaseSuccess.SetActive (true);
			levelmenu.UpdateMainInformation ();

		}else// A consumable product has been purchased by this user.
			if (String.Equals(args.purchasedProduct.definition.id, kProductIDConsumable2, StringComparison.Ordinal))
			{
				Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
				//If the item has been successfully purchased, store the item for later use!
				int totalgems=ZPlayerPrefs.GetInt("totalgems");
				totalgems += 100;
				ZPlayerPrefs.SetInt("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
			    levelmenu.UpdateMainInformation ();

			}else
				// A consumable product has been purchased by this user.
				if (String.Equals(args.purchasedProduct.definition.id, kProductIDConsumable3, StringComparison.Ordinal))
				{
					Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
					//If the item has been successfully purchased, store the item for later use!
					int totalgems=ZPlayerPrefs.GetInt("totalgems");
					totalgems += 500;
					ZPlayerPrefs.SetInt("totalgems", totalgems);
					ZPlayerPrefs.Save ();
					purchaseSuccess.SetActive (true);
			        levelmenu.UpdateMainInformation ();

				}else
					// A consumable product has been purchased by this user.
					if (String.Equals(args.purchasedProduct.definition.id, kProductIDConsumable4, StringComparison.Ordinal))
					{
						Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
						//If the item has been successfully purchased, store the item for later use!
						int totalgems=ZPlayerPrefs.GetInt("totalgems");
						totalgems += 1000;
						ZPlayerPrefs.SetInt("totalgems", totalgems);
						ZPlayerPrefs.Save ();
						purchaseSuccess.SetActive (true);
			            levelmenu.UpdateMainInformation ();

					}else
		// A consumable product has been purchased by this user.
		if (String.Equals(args.purchasedProduct.definition.id, kProductIDConsumable5, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			//If the item has been successfully purchased, store the item for later use!
			int totalgems=ZPlayerPrefs.GetInt("totalgems");
			totalgems += 2000;
			ZPlayerPrefs.SetInt("totalgems", totalgems);
			ZPlayerPrefs.Save ();
			purchaseSuccess.SetActive (true);
			levelmenu.UpdateMainInformation ();

		}else
			// A consumable product has been purchased by this user.
			if (String.Equals(args.purchasedProduct.definition.id, kProductIDConsumable6, StringComparison.Ordinal))
			{
				Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
				//If the item has been successfully purchased, store the item for later use!
				int totalgems=ZPlayerPrefs.GetInt("totalgems");
				totalgems += 5000;
				ZPlayerPrefs.SetInt("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
		    	levelmenu.UpdateMainInformation ();

			}

		else
		{
			Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
			PlayerPrefs.SetInt("Itemss_All", 0);
			purchaseFailed.SetActive (true);

		}
		
		// Return a flag indicating wither this product has completely been received, or if the application needs to be reminded of this purchase at next app launch. Is useful when saving purchased products to the cloud, and when that save is delayed.
		return PurchaseProcessingResult.Complete;
	}


	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		// A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing this reason with the user.
		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}",product.definition.storeSpecificId, failureReason));
		purchaseFailed.SetActive (true);
		failInformation.text = "Purchase failed: " + failureReason.ToString ();
	}

   
}




