Chart.defaults.global = {
	animationSteps: 50,
	tooltipYPadding: 16,
	tooltipCornerRadius: 0,
	tooltipTitleFontStyle: 'normal',
	tooltipFillColor: 'rgba(0,160,0,0.8)',
	animationEasing: 'easeOutBounce',
	scaleLineColor: 'black',
	scaleFontSize: 18,
	padding: 15,
};

const ctxIncExpDashboard =
	document.querySelector('#chartExpIncDashboard') &&
	document.querySelector('#chartExpIncDashboard').getContext('2d');

const ctxExpByCatDashboard =
	document.querySelector('#chartExpCatDashboard') &&
	document.querySelector('#chartExpCatDashboard').getContext('2d');

const ctxIncomes =
	document.querySelector('#chartIncomes') &&
	document.querySelector('#chartIncomes').getContext('2d');

const chart = (type, data, labels, datasetsTitle, title, context) => {
	new Chart(context, {
		type: type,
		data: {
			labels: labels,
			datasets: [
				{
					label: datasetsTitle,
					data: data,
					backgroundColor: [
						'#19f18a',
						'#49c6e5',
						'#fffbfa',
						'#363732',
						'#ef626c',
					],
					borderColor: ['#000000'],
					borderWidth: 1,
				},
			],
		},
		options: {
			plugins: {
				title: {
					display: false,
					text: title,
					color: '#363732',
					padding: {
						top: 10,
						bottom: 20,
					},
					font: {
						family: 'Montserrat',
						size: 36,
						weight: 'normal',
						lineHeight: 1.2,
					},
				},
			},
			scales: {
				y: {
					beginAtZero: true,
				},
			},
			responsive: true,
			maintainAspectRatio: false,
			pointDotRadius: 10,
			bezierCurve: false,
			scaleShowVerticalLines: false,
			scaleGridLineColor: 'black',
		},
	});
};

(() => {
	const incomes = [12, 19, 3, 5, 2, 3, 9, 6, 7, 4, 1, 16];
	const expenses = [-5, -13, -5, -6, -17, -15, -3, -8, -3, -14, -10, -4];
	const labelsMonths = [
		'January',
		'February',
		'March',
		'April',
		'May',
		'June',
		'July',
		'August',
		'September',
		'October',
		'November',
		'December',
	];
	ctxIncExpDashboard &&
		new Chart(ctxIncExpDashboard, {
			type: 'bar',
			data: {
				labels: labelsMonths,
				datasets: [
					{
						label: 'Incomes',
						data: incomes,
						backgroundColor: ['#19f18a'],
						borderColor: ['#000000'],
						borderWidth: 1,
					},
					{
						label: 'Expenses',
						data: expenses,
						backgroundColor: ['#49c6e5'],
						borderColor: ['#000000'],
						borderWidth: 1,
					},
				],
			},
			options: {
				plugins: {
					title: {
						display: false,
						text: 'Incomes and Expenses of 2021',
						color: '#363732',
						padding: {
							top: 10,
							bottom: 20,
						},
						font: {
							family: 'Montserrat',
							size: 36,
							weight: 'normal',
							lineHeight: 1.2,
						},
					},
				},
				scales: {
					y: {
						beginAtZero: true,
					},
				},
				responsive: true,
				maintainAspectRatio: false,
				pointDotRadius: 10,
				bezierCurve: false,
				scaleShowVerticalLines: false,
				scaleGridLineColor: 'black',
			},
		});

	const dataExpensesbyCategory = [-5, -13, -5, -6, -17, -15];

	const labelsCategories = [
		'Netflix',
		'Soccer',
		'Groceries',
		'Cinema',
		'Phone',
		'Internet',
	];

	ctxExpByCatDashboard &&
		chart(
			'doughnut',
			dataExpensesbyCategory,
			labelsCategories,
			'Expenses by Categories',
			'Expenses by Categories',
			ctxExpByCatDashboard
		);

	const dataIncomes = [12, 19, 3, 5, 2, 3, 9, 6, 7, 4, 1, 16];

	ctxIncomes &&
		chart('line', dataIncomes, labelsMonths, 'Incomes', 'Incomes', ctxIncomes);
})();
