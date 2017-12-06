using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HistoryLevel1 {

	private List<string> history = new List<string>();

	public HistoryLevel1(){ 
		history.Add ("Finalmente voy en busqueda " + "\n" + " del cristal, " + "\n" + "tengo que llegar rapido, " + "\n" + " antes de que sea tarde...");
		history.Add ("Necesito alguna pista, una señal," + "\n" + "algo que me diga que estoy " + "\n" + "en el camino correcto...");
		history.Add ("Aqui no esta lo que estoy buscando, " + "\n" + "debo seguir mi camino. " + "\n" + "No se porque huyó con lo que" + "\n" + "me pertenece, aunque si no llego" + "\n" + "rapido ya nada importara...");
	}

	public string getHistoryN(int pos){
		return history.ElementAt(pos);
	}
}
