using System;

int[][] comprime(int[] lista){
    int[][] bytesLista = new int[lista.Length/2][];
    for(int i = 0; i < lista.Length/2; i++){
        bytesLista[i] = new int[8];
    }

    for(int i = 0; i < lista.Length; i++){
        int numero = lista[i];
        int[] bytes = new int[8];
        int index = i/2;
        int parte = i%2;

        for(int x = 7; x >= 0; x--){
            int valor = Convert.ToInt32(Math.Pow(2, x));
            if(numero >= valor){
                numero = numero - valor;
                bytes[x] = 1;
                //Console.WriteLine($"{numero}, ");
            } else{
                bytes[x] = 0;
            }   
        }    

        if(parte == 0){
            for(int x = 7; x >= 4; x--){
                bytesLista[index][x] = bytes[x];
            }
        }else{
            for(int x = 3; x >= 0; x--){
                bytesLista[index][x] = bytes[x+4];
            }
        }
    }

    return bytesLista;
}

int[] descomprime(int[][] lista){
    int[] decodificado = new int[lista.Length*2];
    
    for(int i = 0; i < lista.Length*2; i++){
        if(i % 2 == 0){
            for(int x = 7; x >= 4; x--){
                int valor = Convert.ToInt32(Math.Pow(2, x));
                if(lista[i/2][x] == 1){
                    decodificado[i] += valor;
                }
            }
        } else{
            for(int x = 3; x >= 0; x--){
                int valor = Convert.ToInt32(Math.Pow(2, x + 4));
                if(lista[i/2][x] == 1){
                    decodificado[i] += valor;
                }
            }  
        }
    }

    return decodificado;
}

int[] lista = new int[10];
int[] descodificado = new int[lista.Length];
int[][] valores = new int[lista.Length/2][];

var start = DateTime.Now;
valores = comprime(lista);
descodificado = descomprime(valores);
var final = DateTime.Now;

for(int x = 0; x < valores.Length; x++){
    for(int i = 7; i >= 0; i--){
        Console.Write($"{valores[x][i]}, ");
    }
    Console.WriteLine();
}


for(int i = 0; i < 8; i++){
    Console.Write($"{descodificado[i]}, ");
}

Console.WriteLine($"\n\nTempo decorrido desde o início do programa: {(final - start).TotalMilliseconds} Milisegundos");