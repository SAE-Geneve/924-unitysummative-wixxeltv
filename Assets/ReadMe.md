#Warehouse 

Vous jouez un employé chargé de collecter les paquets.

Ajouter tous les éléements nécessaires au fonctionnement du jeu
- **Physique** : colliders, rigidbodies et materiaux physiques pour la simulation
- **Character controller, InputActions et autres élements** vous donnant la capacié de controler le mouvement du protagoniste, ainsi que la physique appropriée.
- Utilisez le composant/script **BoxCatcher** pour attraper et déposer les cartons. 
- Ajouter un **élement d'interface** permettant de compter les cartons collectées.
- Les boites distribuées ne doivent pas avoir la meme taille. **Utilisez les prefabs** appropriés
![Description du script BoxCatcher](img.png)

- Ajoute une des features suivantes :
  - GamePlay : scoring en temps limité
  - GamePlay : Certaines boites sont explosives (le joueur doit laisser à terre sous peine de perdre la partie)
  - Feedbacks : son de collecte 
  - Feedback : animation de disparition des carton
  - Gestion de la distribution : Les convoyeurs fonctionnent ensemble, le nombre de boites en attente est limité
  - Gestion de la distribution : Les convoyeurs distribuent à tour de role les cartons