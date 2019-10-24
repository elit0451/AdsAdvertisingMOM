# Campaign Advertising Application :postbox::chart_with_upwards_trend:
This repository presents a **MOM** (**M**essage-**o**riented **m**iddleware) :incoming_envelope: implementation for a campain promoting application.

</br>

---
## Functionality :gear:
* An advertising agency offers different campaigns :newspaper: for their clients. A message broker is used for promoting the  offers :rotating_light:;
* Customers of this agency’s services register their topics of interest and related offers come from the same ads channel; :mailbox_with_mail:
* Customers, who are **interested** in the current offer confirm their participation :bellhop_bell: , while those who are **not**, respond with `pass` :no_entry_sign:.

</br>

---
## Set up  :control_knobs:

NB:bangbang: **Before** running our 2 projects, make sure you have _RabbitMQ_ running :rabbit:.  

If you have _Docker_ within reach :whale: you can simply run the following command to start it:
<p align="center"><code>docker run --name rabbitMQ -p 15672:15672 -p 5672:5672 rabbitmq:management</code></p>  

> Optional: To make sure _RabbitMQ_ is running, navigate to `localhost:15672`in your browser

After you have cloned down :arrow_down: this repository, you need to assure you have installed ***RabbitMQ.Client* nuget package for both (**Consumer** and **Producer**) projects.

Run instances of both and follow the instructions :calling:

</br>

___
> #### Assignment made by:   
`David Alves 👨🏻‍💻 ` :octocat: [Github](https://github.com/davi7725) <br />
`Elitsa Marinovska 👩🏻‍💻 ` :octocat: [Github](https://github.com/elit0451) <br />
> Attending "System Integration" course of Software Development bachelor's degree
