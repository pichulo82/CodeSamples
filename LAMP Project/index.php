
<?php
	// index.php -- view the products

	// a session is active for the duration of the browser. The data remains even when the page is left or closed,
	// so long as the browser remains open. This allows the use of saving data across pages which is used in this code
	// where $_SESSION is used
	session_start();

	// include the code from products.php and layout.php -- mandatory
	require( "products.php" );
	require( "layout.php" );
	
	// establish connection to database

	$servername = 'localhost';
	$username = 'root';
	$password = 'forgot';
	$dbName = 'movies';

	// this creates the actual connection to the DB
	$conn = mysql_connect($servername, $username, $password, $dbName) or die("I DIED!");

	// Initialize cart
	// !isset() returns true when no session is active
	if ( !isset( $_SESSION['shopping_cart'] ) )
	{	
		// assign an empty array to the current session
		$_SESSION['shopping_cart'] = array();
	}
	
	// Empty cart
	if ( isset ( $_GET['empty_cart'] ) )
	{
		// user chose "empty cart" - clear the array of items and reset the session
		$_SESSION['shopping_cart'] = array();
	}

	// Process the form

	// the message string that alerts user when cart changes
	$message = '';
	
	// Add product to cart
	// add to cart was chosen (the submit button)
	if ( isset ( $_POST['add_to_cart'] ) )
	{
		$product_id = $_POST['product_id'];
		
		// Check for valid item
		if ( !isset( $products[ $product_id ] ) )
		{
			$message = "Invalid item!<br />";
		}
		
		// If item is already in cart, tell user
		else if ( isset( $_SESSION['shopping_cart'][$product_id] ) )
		{
			$message = "Item already in cart!";
		}

		// Otherwise, add to cart
		else {
			//echo "Line 63: Product ID = " . $product_id;
			
			// The SQL query string. This is just a string, not an actual query
			$sql = "SELECT * FROM movies.moviesTable WHERE movieID = " . $product_id;
			$myQuery = mysql_query($sql) or die("The error is: " . mysql_error()); // this performs the query on the DB

			// create an array from the query executed on previous line
			$row = mysql_fetch_array($myQuery);

			// grab specific fields from database
			$movieId = $row[movieID];
			$movieTitle = $row[movieTitle];
			$movieCat = $row[movieCat];
			$moviePrice = $row[moviePrice];

			// store the queried data in the session. This allows retention of data across pages
			$_SESSION['shopping_cart'][$movieId]['title'] = $movieTitle;
			$_SESSION['shopping_cart'][$movieId]['price'] = $moviePrice;
			$_SESSION['shopping_cart'][$movieId]['category'] = $movieCat;
			$_SESSION['shopping_cart'][$movieId]['quantity'] =  $_POST['quantity'];

			$_SESSION['shopping_cart'][$product_id]['product_id'] = $_POST['product_id'];

			// create a message to output to the page after product added
			$message =
			
				"<script type = 'text/javascript'>
					document.getElementById('message').innerHTML = 'Added to cart';
				</script>";
		}
	}
	
	// Update Cart
	// update_cart is the name of the Submit button in the cart view--thus the below if statement renders true when submit is clicked
	if ( isset( $_POST['update_cart'] ) )
	{
		$quantities = $_POST['quantity']; // get quantity from text box
		echo "<style = 'color: #FFFFFF;'>Line 94: quantities = ", $quantities . "</style>";

		// look at each quantity text box
		foreach ( $quantities as $id => $quantity )
		{
			// if ( !isset( $products[ $id ] ) )
			if ( !isset( $_SESSION['shopping_cart'][$id]['quantity']) )
			{
				$message = "Line 102: Invalid product!";
				break; // exit loop to avoid further processing
			}

			$_SESSION['shopping_cart'][$id]['quantity'] = $quantity;
		}

		if ( !$message ) $message = "Cart updated!<br />";
	}

	// ** DISPLAY PAGE **
	echo $header; // header is from layout.php. This just echoes (displays) the content from the file
	// echo "<span>" . $message . "</span>";

	// View a product
	if ( isset( $_GET['view_product'] ) ) // view_product is set when a product is selected
	{
		$product_id = $_GET['view_product'];

		if ( isset( $product_id ) )
		{
			// Display site links
			echo "<p>
				<a href='./index.php'>Movie Spot</a> &gt; <a href='./index.php'></a>";
			
			$sql = "SELECT movieTitle FROM movies.moviesTable WHERE movieID = " . $product_id;
			
			$myQuery = mysql_query($sql) or die("The error is: " . mysql_error());
			$row = mysql_fetch_array($myQuery); // returns an array corresponding to the row which was fetched. Columns are stored as keys in the array
			
			echo $row[movieTitle];

			echo "</p><div id = 'movieView'>";
				// $products[$product_id]['category'] . "</a></p>";

			// Display product
			echo "<div id = 'imgFloat'>
				<img src = '" . $products[$product_id] . "' width = '250' height = '350' /></div>"; // output the image of selected movie

				// call function to query the database
				dbQuery( $product_id );

				// output form controls 
				echo
					"<form action='./index.php?view_product=$product_id' method='post'>
						<select name='quantity'>
							<option value='1'>1</option>
							<option value='2'>2</option>
							<option value='3'>3</option>
						</select>
						<input type='hidden' name='product_id' value='$product_id' />
						<input type='submit' name='add_to_cart' value='Add to cart' />
						<span id = 'message'></span> <!-- the span to contain the message to appear next to the Add to Cart button -->
						<span>" . $message . "</span>" . // this places the message next to the add button
					"</form>
				</div> <!-- close div movieView -->";
		} else {
			echo "Invalid product!";

		}
	}
	
	// View cart
	else if ( isset( $_GET['view_cart'] ) ) 
	{
		viewCart();
	}

	// Checkout
	else if ( isset( $_GET['checkout'] ) )
	{
		checkout();
	}
	
	// View / display all products
	else { // not on the checkout section
		// Display site links
		echo "<p>
		<a href='./index.php'>Movie Spot</a></p>";
		
		$productCount = 0; // track how many products have been displayed per row

		echo "<div id = 'movies'>
				<h2>Featured Items</h2>
					<div id = 'row'>"; // start first row

		// Loop to display all products
		// products array is from products.php file
		
		$id = 1;
		foreach($products as $index => $path)
		{
			if ($productCount < 5 )
			{
				echo "<a href = './index.php?view_product=$id'><img src = '" . $path . "'width = '150' height = '250' id = 'item' /></a>";

			} else { // five images were displayed

				$productCount = 0;				
				echo
				"</div><hr />" . // close div row, then make a new row
				"<div id = 'row'>
					<a href = './index.php?view_product=$id'><img src = '" . $path . "'width = '150' height = '250' id = 'item' /></a>"; // associate the images to $id
				
			}
			
			// track the products displayed per row
			$productCount = $productCount + 1;
			$id = $id + 1;
		} // end foreach
		
		echo "</div></div>";
	} // end else


// DB Queries
	
	// function to execute database queries
	function dbQuery($id)
	{
		$sql = "SELECT * FROM movies.moviesTable WHERE movieID = " . $id;
		$myQuery = mysql_query($sql) or die("The error is: " . mysql_error());
   
		// this is working !!   
		$row = mysql_fetch_array($myQuery); // returns an array corresponding to the row which was fetched. Columns are stored as keys in the array
		echo "<h2>" . $row[movieTitle] . "</h2>";
		echo "$" . $row[moviePrice];

		$myQuery = mysql_query($sql) or die("The error is: " . mysql_error()); // execute the query and store result
   
		echo "<p><div id = 'description'>" . $row[movieDesc] . "</div></p>"; // passes in a field from the DB as a key to the array then displays
		echo "<div id = 'cast'><p><strong>Cast</strong>: " . $row[movieCast];

		echo "</p></div>";
   	
   	// for some reason, this line is preventing the code from executing after this function is called
		// $conn->close();
	}	

	function viewProduct()
	{

	}

	function viewCart()
	{
		// Display site links
		echo "<div id = 'cartView'><p>
			<a href='./index.php'>Movie Spot</a></p>";

		echo "<h3>Your Cart</h3>
			<p>
				<a href='./index.php?empty_cart=1'>Empty Cart</a>
			</p>";

		if ( empty( $_SESSION['shopping_cart'] ) )
		{
			echo "Your cart is empty.<br /></div>";
		}
		else {
			// cart is not empty, so display the cart items
			echo "<form action='./index.php?view_cart=1' method='post'>
				<table style = 'width:600px;' cellspacing = '0' cellpadding = '5'>
				<tr>
					<th style='border-bottom:1px solid #000000;'>Name</th>
					<th style='border-bottom:1px solid #000000;'>Price</th>
					<th style='border-bottom:1px solid #000000;'>Category</th>
					<th style='border-bottom:1px solid #000000;'>Quantity</th>
				</tr>";
				
			// output each of the items in the cart
			// $index = 1;

			foreach($_SESSION['shopping_cart'] as $id => $product)
			{
				echo "<tr>
					<td style='border-bottom:1px solid #000000;'><a href='./index.php?view_product=$id'>" . 
						$_SESSION['shopping_cart'][$id]['title'] . "</a></td>
					<td style='border-bottom:1px solid #000000;'>$" . $_SESSION['shopping_cart'][$id]['price'] . "</td> 
					<td style='border-bottom:1px solid #000000;'>" . $_SESSION['shopping_cart'][$id]['category'] . "</td>
					<td style='border-bottom:1px solid #000000;'>" .
						"<input type='text' name='quantity[$product_id]' value='" . $product['quantity'] . "' size = '5' /></td></tr>"; // creates an array of quantity text boxes

			} // end foreach

			// make the checkout link on the cart view a button
			// it calls a JS function to set the location of the page to the checkout view 
			echo "</table>
				<div id = 'cartButtons'>
					<input type='submit' name='update_cart' value='Update' />
					<a href='./index.php?checkout=1'></a><input type = 'button' value = 'Checkout' onClick = 'checkOut();' />
				</div>
			</form>
			</div> <!-- close div cartView -->
			
			<script type = 'text/javascript'>
				function checkOut()
				{
					document.location = './index.php?checkout=1';
				}
			</script>";
		}
	} // end function viewCart
	
	function addItem()
	{
		
	}

	// called when user chooses the checkout link
	function checkout()
	{
		// Display site links
		echo "<div id = 'cartView'><p>
			<a href='./index.php'>Movie Spot</a></p>";
	
		echo "<h3>Checkout</h3>";
		
		// looks at the array to see if it is empty. When cart is emptied, the session is set to an empty array, so this will render true
		if ( empty($_SESSION['shopping_cart']) )
		{
			echo "Your cart is empty.<br />";
		}
		else { // cart is not empty, so output the details in a table
			echo "<form action='./index.php?checkout=1' method='post'>
				<table style='width:600px;' cellspacing = '0' cellpadding = '5'>
				<tr>
					<th style='border-bottom:1px solid #000000;'>Name</th>
					<th style='border-bottom:1px solid #000000;'>Item Price</th>
					<th style='border-bottom:1px solid #000000;'>Quantity</th>
					<th style='border-bottom:1px solid #000000;'>Cost</th>
				</tr>";
				
			$itemCost = 0; // the cost of each item
			$itemTotal = 0; // the total cost of each item
			$total_price = 0; // reset total price
			
			foreach ( $_SESSION['shopping_cart'] as $id => $product )
			{
				// $product_id = $product['product_id'];
				
				$itemCost = $_SESSION['shopping_cart'][$id]['price'];
				$productName = $_SESSION['shopping_cart'][$id]['title'];
				$productQuantity = $_SESSION['shopping_cart'][$id]['quantity'];
				
				$itemTotal = $itemCost * $productQuantity;				
				$total_price += $itemTotal; // tally the total price
				
				// output each row in the table to display the products in the cart
				echo "<tr>
					<td style='border-bottom:1px solid #000000;'><a href='./index.php?view_product=$id'>" . 
						$productName . "</a></td>
					<td style='border-bottom:1px solid #000000;'>$" . $itemCost . "</td> 
					<td style='border-bottom:1px solid #000000;'>" . $productQuantity . "</td>
					<td style='border-bottom:1px solid #000000;'>$" . $itemTotal . "</td>
				</tr>";
			} // end foreach

			echo "</table>
			<p>Total price: $" . $total_price . "</p></div>";
		}
	} // end function checkout

	$conn->close(); // close connection to DB

	//echo $footer;

/*
		// used to fetch multiple rows
   	while ( $row = mysql_fetch_array($myQuery) )
   	{
   		// echo $row['movieTitle'] . "<br />" . $row['moviePrice'] . "<br />";
	   	// echo $row[movieDesc];
	   }
*/
	// below ( unset( $_SESSION['shopping_cart']); ) would end a session, thus all of the data that was set would be removed
	// In this case, all of the cart items would be removed
	
	// unset( $_SESSION['shopping_cart']);

?>
