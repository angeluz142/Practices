var users = [
{
	name: 'Juan',
	gender: 'M',
	hobby: 'Sports',
	avatar: '../images/maleavatar.png'
},
{
	name: 'Lenny',
	gender: 'F',
	hobby: 'pets',
	avatar: '../images/womenavatar.png'
},
{
	name: 'Pedro',
	gender: 'M',
	hobby: 'Pool',
	avatar: '../images/maleavatar.png'
},
{
	name: 'Jenny',
	gender: 'F',
	hobby: 'sing',
	avatar: '../images/womenavatar.png'
},
];

window.addEventListener('load', function() {
	//console.log('the page has been loaded!');

var results = document.getElementById('results');

function search(){



	//console.log('Im searching');
	//results.innerHTML = 'Hello World<br/>new line<div>some text</div>';

	//GET Hobby

	var hobbyField = document.getElementById('hobby');
	var hobby = hobbyField.value;
	console.log(hobby);

	//GET Gender

	var genderField = document.getElementById('gender');
	var s = genderField.selectedIndex; // By index
	console.log(s);
	var ss = genderField.options[s].value; // By name options
	console.log(ss);

	var resulthtml = '';
	var usrs = users.length;
	for (var i = 0; i < usrs; i++) {
		//resulthtml = resulthtml + ' ' + users[i].name;

		if (ss == 'A' || ss == users[i].gender) {

			if (hobby =='' || hobby == users[i].hobby) {

				resulthtml += '<div class="person-row">\
						<img src="images/' + users[i].avatar + '">\
							<div class="person-info">\
								<div>' + users[i].name + '</div>\
								<div>' + users[i].hobby + '</div>\
							</div>\
						<button>Add as Friend</button>\
					</div>'

			};
		};

		/*resulthtml += '<div class="person-row">\
						<img src="images/' + users[i].avatar + '">\
							<div class="person-info">\
								<div>' + users[i].name + '</div>\
								<div>' + users[i].hobby + '</div>\
							</div>\
						<button>Add as Friend</button>\
					</div>'*/
		};

	results.innerHTML = resulthtml;
}

	var searchBt = document.getElementById('searchBtn');
	//console.log(searchBt);

	searchBt.addEventListener('click', search);

});