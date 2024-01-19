package io.chimoney.chimoney;

public class ChimoneyException extends Exception {
	private String msg;

	ChimoneyException(String msg) {
		this.msg = msg;
	}

	public String toString() {
		return "ChimoneyException: " + msg;
	}
}
