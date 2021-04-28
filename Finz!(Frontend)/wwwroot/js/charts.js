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
