
<?php
	/*
		index.php -- view the products
	*/

	// a session is active for the duration of the browser. The data remains even when the page is left or closed,
	// so long as the browser remains open. This allows the use of saving data across pages which is used in this code
	// where $_SESSION is used
	session_start();

	// include the code from products.php and layout.php -- mandatory
	require( "products.php" );
	require( "layout.php" );

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
			$message = "Item already in cart!<br />";
		}
		
		// Otherwise, add to cart
		else {
			$_SESSION['shopping_cart'][$product_id]['product_id'] = $_POST['product_id'];
			$_SESSION['shopping_cart'][$product_id]['quantity'] = $_POST['quantity'];
			$message = "Added to cart!";
		}
	}
	
	// Update Cart
	// update_cart is the name of the Submit button--thus the below if statement renders true when submit is clicked
	if ( isset( $_POST['update_cart'] ) )
	{
		$quantities = $_POST['quantity'];

		foreach ( $quantities as $id => $quantity )
		{
			if ( !isset( $products[ $id ] ) )
			{
				$message = "Invalid product!";
				break; // exit loop to avoid further processing
			}

			$_SESSION['shopping_cart'][$id]['quantity'] = $quantity;
		}

		if ( !$message ) $message = "Cart updated!<br />";
	}

	// ** DISPLAY PAGE **
	echo $header; // header is from layout.php. This just echoes (displays) the content from the file
	echo $message;

	// View a product
	if ( isset( $_GET['view_product'] ) ) // view_product is set when a product is selected
	{
		$product_id = $_GET['view_product'];
		if ( isset( $products[$product_id] ) )
		{
			// Display site links
			echo "<p>
				<a href='./index.php'>Movie Spot</a> &gt; <a href='./index.php'>" .
				$products[$product_id]['category'] . "</a></p>";

			// Display product
			echo "<p>
				<img src = '" . $products[$product_id]['image'] . "' id = 'imgFloat' width = '150' height = '250' />" . // output the image of selected movie
				"<h3>" . $products[$product_id]['name'] . "</h3>" . // outputs title of selected movie
				"<span>$" . $products[$product_id]['price'] . "</span><br />" . // outputs price of selected movie
				"<span>" . $products[$product_id]['description'] . "</span><br />
				
				<p>" . // output form controls 
					"<form action='./index.php?view_product=$product_id' method='post'>
						<select name='quantity'>
							<option value='1'>1</option>
							<option value='2'>2</option>
							<option value='3'>3</option>
						</select>
						<input type='hidden' name='product_id' value='$product_id' />
						<input type='submit' name='add_to_cart' value='Add to cart' />
					</form>
				</p>
			</p>";
		} else { 
			echo "Invalid product!";
		}
	}
	
	// View cart
	else if ( isset( $_GET['view_cart'] ) ) 
	{
		// Display site links
		echo "<p>
			<a href='./index.php'>Movie Spot</a></p>";

		echo "<h3>Your Cart</h3>
			<p>
				<a href='./index.php?empty_cart=1'>Empty Cart</a>
			</p>";

		if ( empty( $_SESSION['shopping_cart'] ) )
		{
			echo "Your cart is empty.<br />";
		}
		else {
			// cart is not empty, so display the cart items
			echo "<form action='./index.php?view_cart=1' method='post'>
				<table style = 'width:500px;' cellspacing = '0' cellpadding = '5'>
				<tr>
					<th style='border-bottom:1px solid #000000;'>Name</th>
					<th style='border-bottom:1px solid #000000;'>Price</th>
					<th style='border-bottom:1px solid #000000;'>Category</th>
					<th style='border-bottom:1px solid #000000;'>Quantity</th>
				</tr>";
				
			// output each of the items in the cart
			foreach($_SESSION['shopping_cart'] as $id => $product) {
				$product_id = $product['product_id'];
					
				// items have an
				echo "<tr>
					<td style='border-bottom:1px solid #000000;'><a href='./index.php?view_product=$id'>" . 
						$products[$product_id]['name'] . "</a></td>
					<td style='border-bottom:1px solid #000000;'>$" . $products[$product_id]['price'] . "</td> 
					<td style='border-bottom:1px solid #000000;'>" . $products[$product_id]['category'] . "</td>
					<td style='border-bottom:1px solid #000000;'>
						<input type='text' name='quantity[$product_id]' value='" . $product['quantity'] . "' size = '5' /></td>
				</tr>";
			} // end foreach
				
			echo "</table>
			<input type='submit' name='update_cart' value='Update' />
			</form>
			<p>
				<a href='./index.php?checkout=1'>Checkout</a>
			</p>";
		
		}
	}

	// Checkout
	else if ( isset( $_GET['checkout'] ) )
	{	
		// Display site links
		echo "<p>
			<a href='./index.php'>Movie Spot</a></p>";
	
		echo "<h3>Checkout</h3>";
		
		// looks at the array to see if it is empty. When cart is emptied, the session is set to an empty array, so this will render true
		if ( empty($_SESSION['shopping_cart']) )
		{
			echo "Your cart is empty.<br />";
		}
		else { // cart is not empty, so output the details in a table
			echo "<form action='./index.php?checkout=1' method='post'>
				<table style='width:500px;' cellspacing='0'>
				<tr>
					<th style='border-bottom:1px solid #000000;'>Name</th>
					<th style='border-bottom:1px solid #000000;'>Item Price</th>
					<th style='border-bottom:1px solid #000000;'>Quantity</th>
					<th style='border-bottom:1px solid #000000;'>Cost</th>
				</tr>";
				
			$total_price = 0; // reset total price
			
			foreach ( $_SESSION['shopping_cart'] as $id => $product )
			{
				$product_id = $product['product_id'];
	
				$total_price += $products[$product_id]['price'] * $product['quantity']; // calculate the total price
				
				// output each row in the table to display the products in the cart
				echo "<tr>
					<td style='border-bottom:1px solid #000000;'><a href='./index.php?view_product=$id'>" . 
						$products[$product_id]['name'] . "</a></td>
					<td style='border-bottom:1px solid #000000;'>$" . $products[$product_id]['price'] . "</td> 
					<td style='border-bottom:1px solid #000000;'>" . $product['quantity'] . "</td>
					<td style='border-bottom:1px solid #000000;'>$" . ($products[$product_id]['price'] * $product['quantity']) . "</td>
				</tr>";
			} // end foreach

			echo "</table>
			<p>Total price: $" . $total_price . "</p>";
		}
	}
	
	// View all products
	else { // not on the checkout section
		// Display site links
		echo "<p>
		<a href='./index.php'>Movie Spot</a></p>";
	
		echo "<h3>Our Products</h3>";

		echo "<table style='width:500px;' cellspacing='0'>";
		echo "<tr>
			<th style='border-bottom:1px solid #000000;'>Name</th>
			<th style='border-bottom:1px solid #000000;'>Price</th>
			<th style='border-bottom:1px solid #000000;'>Category</th>
		</tr>";

		// Loop to display all products
		// products array is from products.php file
		foreach($products as $id => $product)
		{
			echo "<tr>
				<td style='border-bottom:1px solid #000000;'><a href='./index.php?view_product=$id'>" . $product['name'] . "</a></td>
				<td style='border-bottom:1px solid #000000;'>$" . $product['price'] . "</td>
				<td style='border-bottom:1px solid #000000;'>" . $product['category'] . "</td>
				</tr>";
		}
		
		echo "</table>";
	}

	echo $footer;
	
	// below ( unset( $_SESSION['shopping_cart']); ) would end a session, thus all of the data that was set would be removed
	// In this case, all of the cart items would be removed
	
	// unset( $_SESSION['shopping_cart']);

?>
