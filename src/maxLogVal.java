
public class maxLogVal {

	public maxLogVal() {
		// TODO Auto-generated constructor stub
	}
	
	public int evaluate(double time){
		double logVal = Math.log(Math.log(.1*time));
		//System.out.println(logVal);
		double val = 1/(.5*logVal + .6891);
		int rate = (int)(60*val);
		return rate;
	}
	
	public void printMax(){
		int maxDif = 25;
		while(evaluate(maxDif)!= 0){
			System.out.println("Difficulty Level: "+ maxDif + " Rate: "+evaluate(maxDif));
			maxDif++;
		}
		System.out.println(maxDif);
	}

}
