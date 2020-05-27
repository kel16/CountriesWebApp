import React from 'react'
import { Form, Field } from 'react-final-form'
import { Typography, Button } from '@material-ui/core'
import axios from 'axios'

import { TextField } from '../theme'

const Update = ({ country }) => {
	const required = (value) => (value ? undefined : '*required field*')
	const [submitted, setSubmitted] = React.useState(false)

	const onSubmit = (values, form) => {
		axios({
			method: 'post',
			url: `/api/Countries/add-country`,
			data: values,
		})
			.then(function (response) {
				if (response.status != 200) {
					throw Error(`Response status: ${response.status}`)
				} else {
					setSubmitted(true)
					setTimeout(form.reset)
				}
			})
			.catch(function (error) {
				console.log(error)
			})
	}

	return (
		<Form
			onSubmit={onSubmit}
			initialValues={{
				name: country.code,
				code: country.code,
				area: country.area,
				population: country.population,
				region: country.region,
				capital: country.capital,
			}}
			render={({ handleSubmit, form, submitting, pristine, values }) => (
				<form onSubmit={handleSubmit}>
					<div>
						<Field
							name='name'
							component={TextField}
							validate={required}
							type='text'
							label='Название страны'
							warning='Поле обязательно для заполнения'
						/>
					</div>
					<div>
						<Field
							name='code'
							component={TextField}
							type='text'
							label='Код страны'
							disabled
						/>
					</div>
					<div>
						<Field
							name='area'
							component={TextField}
							validate={required}
							type='number'
							label='Площадь'
							warning='Поле обязательно для заполнения'
						/>
					</div>
					<div>
						<Field
							name='population'
							component={TextField}
							validate={required}
							type='number'
							label='Население'
							warning='Поле обязательно для заполнения'
						/>
					</div>
					<div>
						<Field
							name='region'
							component={TextField}
							validate={required}
							type='text'
							label='Название региона'
							warning='Поле обязательно для заполнения'
						/>
					</div>
					<div>
						<Field
							name='capital'
							component={TextField}
							validate={required}
							type='text'
							label='Название столицы'
							warning='Поле обязательно для заполнения'
						/>
					</div>
					<div>
						{!submitted ? (
							<Button
								variant='outlined'
								color='primary'
								type='submit'
								disabled={submitting || pristine}>
								Отправить
							</Button>
						) : (
							<Typography>Форма отправлена</Typography>
						)}
					</div>
					<pre>{JSON.stringify(values, 0, 2)}</pre>
				</form>
			)}
		/>
	)
}

export default Update
