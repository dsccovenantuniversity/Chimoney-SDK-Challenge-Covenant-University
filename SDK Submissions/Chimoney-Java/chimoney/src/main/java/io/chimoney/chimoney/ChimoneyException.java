package io.chimoney.chimoney;

/**
 * This class represents an exception specific to the Chimoney application.
 */
public class ChimoneyException extends Exception {
	private String msg;

	/**
	 * Constructs a new ChimoneyException with the specified error message.
	 *
	 * @param msg the error message
	 */
	ChimoneyException(String msg) {
		this.msg = msg;
	}

	/**
	 * Returns a string representation of this ChimoneyException.
	 *
	 * @return the string representation of this ChimoneyException
	 */
	public String toString() {
		return "ChimoneyException: " + msg;
	}
}
