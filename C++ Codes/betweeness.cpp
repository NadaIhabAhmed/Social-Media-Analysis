#include "pch.h"
#include <iostream>
#include <vector>
#include <set>
#include <climits>

using namespace std;

// Number of vertices in the graph
//#define V 9

int minDistance(vector<int> dist, vector<bool> sptSet, int v); // first mod
void printSolution(vector<int> dist, int k, int src, int target, vector <int> parent); // second mod
float dijkstra(vector <vector<int> > graph, int src,int target, int v, int check);
void printPath(vector <int> parent, int j);


int main()
{
	int n, m;
	cin >> n >> m;
	vector <vector<int> > adj_matrix(n, vector<int>(n, 0));
	vector <int> count;
	int a, b, c;
	for (int i = 0; i < m; i++)
	{
		cin >> a >> b >> c;
		adj_matrix[a][b] = c;
		adj_matrix[b][a] = c;
	}

	for (int i = 0; i < n; i++)
	{
		int counter = 0;
		for (int j = 0; j < n; j++)
		{
			if (adj_matrix[i][j] != 0)
				counter++;
		}
		count.push_back(counter);
	}

	/*for (int i = 0; i < n; i++)    // check the degree
	{
		cout << count[i] << endl;
	}*/


	/////////////////////////////////////////////////////////////////////////

	float aaa = dijkstra(adj_matrix, 0,4, n, 0);

	/*for (int i = 0; i < n; i++)
	{
		cout << (n - 1) / (dijkstra(adj_matrix, i, n)) << endl;
	}*/

	/*
	3shan el brnameg my2flsh
	int wait;
	cin >> wait;
	*/

	return 0;
}

int minDistance(vector<int> dist, vector<bool> sptSet, int v)
{

	int min = INT_MAX, min_index;

	for (int w = 0; w < v; w++)
	{
		if (sptSet[w] == false && dist[w] <= min)
		{
			min = dist[w], min_index = w;
		}
	}
	return min_index;
}

void printSolution(vector<int> dist, int k ,int src, int target, vector <int> parent)
{
	/*printf("Vertex\t Distance\tPath");
	for (int i = 0; i < 1; i++)
	{
		printf("\n%d -> %d \t\t %d\t\t%d ",src, 1, dist[i], src);
		printPath(parent, i);
	}*/

	printf("\n%d -> %d \t\t %d\t\t%d ", src, target, dist[target], src);
	printPath(parent, target);
}

void printPath(vector <int> parent, int target)
{
	if (parent[target] == -1)
		return;
	printPath(parent, parent[target]);
	cout << target << " ";
}

float dijkstra(vector <vector<int> > graph, int src, int target, int v , int check)
{
	vector<int> dist(v, 0);
	vector<bool> sptSet(v, 0);
	vector <int> parent(v);

	parent[src] = -1;


	for (int i = 0; i < v; i++)
	{
		dist[i] = INT_MAX, sptSet[i] = false;
	}

	dist[src] = 0;

	for (int count = 0; count < v - 1; count++)
	{
		int u = minDistance(dist, sptSet, v);

		sptSet[u] = true;

		for (int w = 0; w < v; w++)
		{
			if (!sptSet[w] && graph[u][w] && dist[u] != INT_MAX && dist[u] + graph[u][w] < dist[w])
			{
				dist[w] = dist[u] + graph[u][w];
				parent[w] = u;
			}
		}
	}

	float temp = 0;
	for (int i = 0; i < v; i++)
	{
		temp = temp + dist[i];
	}

	if (check)
	{
		printSolution(dist, v , src ,  target, parent);
		return temp;
	}

	return temp;

	// print the constructed distance array
	//printSolution(dist, v);

}
