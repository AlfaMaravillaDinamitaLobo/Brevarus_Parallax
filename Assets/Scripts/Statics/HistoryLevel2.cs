using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HistoryLevel2 {

	private List<string> history = new List<string>();

	public HistoryLevel2(){ 
		history.Add ("Creo que ya estoy cerca " + "\n" + " del cristal, " + "\n" + "ya puedo verlo a lo lejos, debe ser... " + "\n" + "aunque recuerdo haber " + "\n" + "pasado por aqui");
		history.Add ("Crees que te puedes escapar de mi?" + "\n" + "Muestrate de una vez");
		history.Add ("Ahora que ya recupere mi cristal " + "\n" + "y pude destruirlo" + "\n" + "mi venganza esta completa" + "\n" + "que debo hacer ahora..." + "\n" + "Destruir algun planeta?");
	}

	public string getHistoryN(int pos){
		return history.ElementAt(pos);
	}
}
