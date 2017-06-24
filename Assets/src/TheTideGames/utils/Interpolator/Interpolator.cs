using UnityEngine;

namespace TheTideGames.utils.Interpolator
{
	public abstract class Interpolator<T> : MonoBehaviour
	{
		protected float extrapolationLimit;
		private bool m_interpolation = true;
		private T m_target;
		protected float passedTime;

		public delegate void InterpolationDone();
		public delegate void InterpolationInterrupted();

		public T CurrentValue { get; private set; }

		public T Target
		{
			get { return m_target; }
			set
			{
				m_target = value;

				if (passedTime < Time && InterpolationInterruptedEvent != null)
				{
					InterpolationInterruptedEvent();
				}

				passedTime = 0;
				Entry = CurrentValue;

				if (!m_interpolation)
				{
					CurrentValue = m_target;
					Done = true;
					return;
				}

				Done = false;
			}
		}

		public float Time { get; set; }

		public bool Done { get; private set; }

		public T Entry { get; private set; }

		public virtual bool Interpolation
		{
			get { return m_interpolation; }

			set
			{
				m_interpolation = value;

				if (m_interpolation) return;
				CurrentValue = Target;
				Done = true;
			}
		}

		public event InterpolationDone InterpolationDoneEvent;
		public event InterpolationInterrupted InterpolationInterruptedEvent;

		/// <summary>
		/// Setup the basic vaules for Interpolation
		/// </summary>
		/// <param name="interpolationTime"></param>
		/// Time in seconds it will take to interpolate (100ms = 0.1f)
		/// <param name="entry"></param>
		/// initial CurrentValue
		/// <param name="target"></param>
		/// inital Target (can be the same as entry)
		/// <param name="extrapolationLimit"></param>
		/// Time in seconds to extrapolate
		public virtual void Setup(float interpolationTime, T entry, T target, float extrapolationLimit = 0)
		{
			passedTime = 0;
			Entry = entry;
			CurrentValue = entry;
			Target = target;
			Time = interpolationTime;
			this.extrapolationLimit = extrapolationLimit;
		}

		void Update()
		{
			if (!m_interpolation || Done) return;

			passedTime += UnityEngine.Time.deltaTime;

			if (passedTime >= Time + extrapolationLimit)
			{
				Done = true;
				CurrentValue = Target;

				if (InterpolationDoneEvent != null)
				{
					InterpolationDoneEvent();
				}

				return;
			}

			CurrentValue = InterpolationStep();
		}

		protected abstract T InterpolationStep();
	}
}